using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerGridMovement : BaseGridMovement
{
    private int _lastViewTileHash;

    //TODO
    public delegate void DescriptionEventHandler(string description);
    public event DescriptionEventHandler OnShowTileName;
    public PlayerGridMovement(Character character, List<Tilemap> obstacleTilemaps) : base (character, obstacleTilemaps)
    {

    }

    public override void SetNextPoint(Vector2Int targetPoint)
    {
        EnvironmentTile tile = GetSolidTile(targetPoint);


        // ui tile preview name
        if (tile != null)
        {
            if (_lastViewTileHash != tile.GetHashCode())
            {
                OnShowTileName?.Invoke(tile.Description);
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
