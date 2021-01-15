using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerGridMovement : BaseGridMovement
{
    private int _lastViewTileHash;

    //todo
    public delegate void NotificationHandler(string description);
    public event NotificationHandler OnWallCollision;

    public PlayerGridMovement(Character character, List<Tilemap> obstacleTilemaps) : base (character, obstacleTilemaps)
    {

    }

    public override Vector2 GetNextPoint()
    {
        if (CurrentPath.Count == 1)
        {
            InvokeCollisionNotification(CurrentPath.Peek());
        }

        return CurrentPath.Dequeue();
    }

    public override void MoveCharacterTo(Direction targetDirection)
    {
        base.MoveCharacterTo(targetDirection);

        var targetPoint = GetPointFromDirection(targetDirection);
        InvokeCollisionNotification(targetPoint);
    }

    private void InvokeCollisionNotification(Vector2Int tagetCell)
    {
        EnvironmentTile tile = GetSolidTile(tagetCell);
        // ui tile preview name
        if (tile != null)
        {
            if (_lastViewTileHash != tile.GetHashCode())
            {
                OnWallCollision?.Invoke(tile.Description);
                // ui event
                Debug.Log(tile.Description);
            }
            _lastViewTileHash = tile.GetHashCode();
        }
        else
        {
            _lastViewTileHash = default;
        }
    }

}
