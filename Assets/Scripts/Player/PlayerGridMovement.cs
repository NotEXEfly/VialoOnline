using System.Collections;
using System.Collections.Generic;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PlayerGridMovement : BaseGridMovement
{
    public PlayerGridMovement(Vector2 currentPoint, Tilemap solidTilemap) : base (currentPoint, solidTilemap)
    {

    }
}
