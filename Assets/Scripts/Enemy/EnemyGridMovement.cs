using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyGridMovement : BaseGridMovement
{
    public EnemyGridMovement(Vector2 currentPoint, Tilemap solidTilemap) : base(currentPoint, solidTilemap)
    {
        CreateStaticPath();
    }

    public void CreateStaticPath()
    {
        CurrentPath.Enqueue(new Vector2(8, 0));
        CurrentPath.Enqueue(new Vector2(9, 0));
        CurrentPath.Enqueue(new Vector2(10, 0));

        CurrentPath.Enqueue(new Vector2(10, -1));
        CurrentPath.Enqueue(new Vector2(10, -2));
        CurrentPath.Enqueue(new Vector2(10, -3));

        CurrentPath.Enqueue(new Vector2(9, -3));
        CurrentPath.Enqueue(new Vector2(8, -3));
        CurrentPath.Enqueue(new Vector2(7, -3));

        CurrentPath.Enqueue(new Vector2(7, -2));
        CurrentPath.Enqueue(new Vector2(7, -1));
        CurrentPath.Enqueue(new Vector2(7, 0));
    }
}
