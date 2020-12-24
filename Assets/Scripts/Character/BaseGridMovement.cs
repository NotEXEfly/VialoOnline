using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class BaseGridMovement
{
    public Queue<Vector2Int> CurrentPath { get; private set; } = new Queue<Vector2Int>();
    protected Character _character;

    // patfinder
    private List<Tilemap> obstacleTilemaps;
    private List<PathFindingNode> path;
    private PathFinder _pathFinder = new PathFinder();
    private UnityTilemapGrid _grid;

    public BaseGridMovement(Character character, List<Tilemap> obstacleMaps)
    {
        _character = character;
        obstacleTilemaps = obstacleMaps;
        _grid = new UnityTilemapGrid { obstacleMaps = obstacleTilemaps };
    }

    public Vector2 GetNextPoint()
    {  
        return CurrentPath.Dequeue();
    }

    public abstract void SetNextPoint(Vector2Int targetPoint);

    protected EnvironmentTile GetSolidTile(Vector2 targetPos)
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

    public void SetNewPath(Vector2Int targetCellPoint)
    {
        CurrentPath.Clear();
        path = null;

        var playerRoundPoint = new Vector2Int(Mathf.RoundToInt(_character.Components.NextCellPoint.position.x), Mathf.RoundToInt(_character.Components.NextCellPoint.position.y));

        _pathFinder.Set(_grid, playerRoundPoint.x, playerRoundPoint.y, targetCellPoint.x, targetCellPoint.y);
        path = _pathFinder.Seek();

        foreach (PathFindingNode item in path)
        {
            CurrentPath.Enqueue(new Vector2Int(item.x, item.y));
        }
    }
}
