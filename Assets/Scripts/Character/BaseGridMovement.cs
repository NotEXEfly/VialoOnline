using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BaseGridMovement
{
    public Queue<Vector2> CurrentPath { get; private set; }

    private Tilemap _solidTilemap;
    private Queue<Vector2> _helpQueue;
    private int _lastViewTileHash;

    public BaseGridMovement(Vector2 currentPoint, Tilemap solidTilemap)
    {
        _solidTilemap = solidTilemap;
        CurrentPath = new Queue<Vector2>();
        CurrentPath.Enqueue(currentPoint);
        _helpQueue = new Queue<Vector2>();
    }

    public Vector2 GetNextPoint()
    {
        
        return CurrentPath.Dequeue();
    }

    public void SetNextPoint(Vector2 targetPoint)
    {
        EnvironmentTile tile = GetSolidTile(targetPoint);
        

        // ui tile preview name
        if (tile != null )
        {
            if (_lastViewTileHash != tile.GetHashCode())
            {
                // ui event
                Debug.Log(tile.Description);
            }
            _lastViewTileHash = tile.GetHashCode();
            return;
        }
        _lastViewTileHash = default;

        if (tile == null)
        {
            CurrentPath.Clear();
            CurrentPath.Enqueue(targetPoint);
        }   
    }

    public IEnumerator SetNextPointWithDelay(float delay)
    {
        if (delay == 0) yield break;

        while (true)
        {
            yield return new WaitForSeconds(delay);

            Debug.Log("hello Courutine");
        }
        
    }

    protected EnvironmentTile GetSolidTile(Vector2 targetPos)
    {
        Vector3Int _trueTargetPos = new Vector3Int((int)targetPos.x - 1, (int)targetPos.y - 1, 0);
        return _solidTilemap.GetTile<EnvironmentTile>(_trueTargetPos);
    }
}
