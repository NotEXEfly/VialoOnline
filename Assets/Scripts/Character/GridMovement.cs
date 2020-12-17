using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridMovement
{
    public Queue<Vector2> CurrentPath { get; private set; }

    private Tilemap _solidTilemap;

    public GridMovement(Vector2 currentPoint, Tilemap solidTilemap)
    {
        _solidTilemap = solidTilemap;
        CurrentPath = new Queue<Vector2>();
        CurrentPath.Enqueue(currentPoint);
    }

    public Vector2 GetNextPoint()
    {
        
        return CurrentPath.Dequeue();
    }

    public void SetNextPoint(Vector2 targetPoint)
    {
        //try
        //{
        //    Vector3Int vector = new Vector3Int((int)targetPoint.x - 1, (int)targetPoint.y - 1, 0);
        //    EnvironmentTile tile = _solidTilemap.GetTile<EnvironmentTile>(vector);
        //    Debug.Log($"{vector} - {tile?.Description}");
        //}
        //catch (System.Exception ex)
        //{
        //    Debug.Log(ex);
        //}
        


        CurrentPath.Clear();
        CurrentPath.Enqueue(targetPoint);
    }

    public IEnumerator SetNextPointWithDelay(float delay)
    {
        if (delay == 0) yield break;
        yield return new WaitForSeconds(delay);


    }
}
