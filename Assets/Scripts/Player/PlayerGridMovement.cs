using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerGridMovement : BaseGridMovement
{
    private int _lastViewTileHash;

    public PlayerGridMovement(Transform characterCellPoint, List<Tilemap> obstacleTilemaps) : base (characterCellPoint, obstacleTilemaps)
    {

    }

    public override void SetNextPoint(Vector2 targetPoint)
    {
        EnvironmentTile tile = GetSolidTile(targetPoint);


        // ui tile preview name
        if (tile != null)
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

}
