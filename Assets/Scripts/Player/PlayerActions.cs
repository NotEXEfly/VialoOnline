using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : CharacterActions
{
    private Player _player;
    private PlayerGridMovement _gridMovement;

    public PlayerGridMovement GridMovement { get => _gridMovement; set => _gridMovement = value; }

    public PlayerActions(Player player) : base (player) 
    {
        _player = player;
        _gridMovement = new PlayerGridMovement(_player, _player.Components.ObstacleTilemaps);
    }

    public void SelectCellPoint()
    {
        // idle animation direction on stay
        if (CellMovement.IsReadyMove && _player.Utilities.InputDirection != Direction.NONE)
            _player.Stats.ViewDirection = _player.Utilities.InputDirection;

        // wasd/joystick movement
        if (CellMovement.IsReadyMove)
        {
            if (_player.Utilities.InputDirection != Direction.NONE)
            {
                GridMovement.MoveCharacterTo(_player.Utilities.InputDirection);
            }
        }

        // move to next point from list
        if (CellMovement.IsReadyMove)
        {
            GridMovement.SetNextPoint();
        }
    }

    public override void MoveByPath(Vector2Int targetCell)
    {
        var newPath = GridMovement.BuildPath(targetCell);
        GridMovement.SetNewPath(newPath);
    }
}
