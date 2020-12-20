using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public abstract class BaseGridMovement
{
    public Queue<Vector2> CurrentPath { get; private set; } = new Queue<Vector2>();

    private Tilemap _solidTilemap;
    
    public BaseGridMovement(Vector2 currentPoint, Tilemap solidTilemap)
    {
        _solidTilemap = solidTilemap;
        CurrentPath.Enqueue(currentPoint);
    }

    public Vector2 GetNextPoint()
    {  
        return CurrentPath.Dequeue();
    }

    public abstract void SetNextPoint(Vector2 targetPoint);


    protected EnvironmentTile GetSolidTile(Vector2 targetPos)
    {
        Vector3Int _trueTargetPos = new Vector3Int((int)targetPos.x - 1, (int)targetPos.y - 1, 0);
        return _solidTilemap.GetTile<EnvironmentTile>(_trueTargetPos);
    }
}
