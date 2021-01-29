using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class BaseGridMovement
{
    public Queue<Vector2Int> CurrentPath { get; private set; } = new Queue<Vector2Int>();
    public UnityTilemapGrid TilemapGrid { get => _tilemapGrid; set => _tilemapGrid = value; }

    protected Character _character;

    // patfinder
    private List<Tilemap> obstacleTilemaps;
    private List<PathFindingNode> path;
    private PathFinder _pathFinder = new PathFinder();
    private UnityTilemapGrid _tilemapGrid;

    public BaseGridMovement(Character character, List<Tilemap> obstacleMaps)
    {
        _character = character;
        obstacleTilemaps = obstacleMaps;
        _tilemapGrid = new UnityTilemapGrid { obstacleMaps = obstacleTilemaps };
    }

    public virtual Vector2 GetNextPoint()
    {  
        return CurrentPath.Dequeue();
    }

    public Queue<Vector2Int> BuildPath(Vector2Int targetCellPoint)
    {
        Queue<Vector2Int> newPath = new Queue<Vector2Int>();
        var playerRoundPoint = new Vector2Int(Mathf.RoundToInt(_character.Components.RealPosition.position.x), Mathf.RoundToInt(_character.Components.RealPosition.position.y));

        _pathFinder.Set(_tilemapGrid, playerRoundPoint.x, playerRoundPoint.y, targetCellPoint.x, targetCellPoint.y);
        path = _pathFinder.Seek();

        foreach (PathFindingNode item in path)
        {
            newPath.Enqueue(new Vector2Int(item.x, item.y));
        }

        path = null;

        return newPath;
    }

    public void SetNewPath(Queue<Vector2Int> newPath)
    {
        CurrentPath.Clear();
        CurrentPath = newPath;
    }

    public virtual void MoveCharacterTo(Direction targetDirection)
    {
        var targetPoint = MoveDirection.GetPoint(targetDirection, _character);
        var tile = GetSolidTile(targetPoint);

        if (tile == null)
        {
            CurrentPath.Clear();
            CurrentPath.Enqueue(targetPoint);
        }
    }

    public EnvironmentTile GetSolidTile(Vector2 targetPos)
    {
        Vector3Int _trueTargetPos = new Vector3Int((int)targetPos.x - 1, (int)targetPos.y - 1, 0);

        foreach (Tilemap tilemap in obstacleTilemaps)
        {
            EnvironmentTile tile = tilemap.GetTile<EnvironmentTile>(_trueTargetPos);
            if (tile != null)
                return tile;
        }

        return null;
    }
}
