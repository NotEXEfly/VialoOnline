using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyGridMovement : BaseGridMovement
{
    public EnemyGridMovement(Character character, List<Tilemap> obstacleTilemaps) : base(character, obstacleTilemaps)
    {
        //CreateStaticPath();
    }

    public void CreateStaticPath()
    {
        CurrentPath.Enqueue(new Vector2Int(8, 0));
        CurrentPath.Enqueue(new Vector2Int(9, 0));
        CurrentPath.Enqueue(new Vector2Int(10, 0));

        CurrentPath.Enqueue(new Vector2Int(10, -1));
        CurrentPath.Enqueue(new Vector2Int(10, -2));
        CurrentPath.Enqueue(new Vector2Int(10, -3));

        CurrentPath.Enqueue(new Vector2Int(9, -3));
        CurrentPath.Enqueue(new Vector2Int(8, -3));
        CurrentPath.Enqueue(new Vector2Int(7, -3));

        CurrentPath.Enqueue(new Vector2Int(7, -2));
        CurrentPath.Enqueue(new Vector2Int(7, -1));
        CurrentPath.Enqueue(new Vector2Int(7, 0));
    }
}
