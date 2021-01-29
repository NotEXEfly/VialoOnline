using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerGridMovement : BaseGridMovement
{
    public delegate void NotificationHandler(string description);
    public event NotificationHandler OnWallCollision;

    private int _lastViewTileHash;
    private Player _player;

    public PlayerGridMovement(Character character, List<Tilemap> obstacleTilemaps) : base (character, obstacleTilemaps) 
    {
        _player = character as Player;
    }

    public void SetNextPoint()
    {
        if (CurrentPath.Count <= 0) return;

        Vector2Int nextPoint = CurrentPath.Peek();

        if (CurrentPath.Count == 1 && !TilemapGrid.IsWalkable(nextPoint.x, nextPoint.y))
        {
            _player.Stats.ViewDirection = MoveDirection.FromNextPoint(new Vector2(nextPoint.x, nextPoint.y), _player);

            InvokeCollisionNotification(nextPoint);
            CurrentPath.Dequeue();
            return;
        }
        else
        {
            _character.Components.RealPosition.position = new Vector3(nextPoint.x, nextPoint.y, 0);
            CurrentPath.Dequeue();
        }  
    }

    public override void MoveCharacterTo(Direction targetDirection)
    {
        base.MoveCharacterTo(targetDirection);

        var targetPoint = MoveDirection.GetPoint(targetDirection, _player);
        InvokeCollisionNotification(targetPoint);
    }

    private void InvokeCollisionNotification(Vector2Int targetPoint)
    {
        EnvironmentTile tile = GetSolidTile(targetPoint);
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
