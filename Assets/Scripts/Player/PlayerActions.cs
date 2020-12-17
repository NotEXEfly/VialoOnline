using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : CharacterActions
{
    private Player _player;
    public PlayerActions(Player player) : base (player) 
    {
        _player = player;
    }

    public override void GoToNextCell()
    {
        _character.Components.NextCellPoint.position = _gridMovement.GetNextPoint();
        
    }

    public override void SetNextCell()
    {
        if (_player.Utilities.InputDirection != Direction.NONE)
        {
            _gridMovement.SetNextPoint(getInputNextPoint(_player.Utilities.InputDirection));
        }
    }


    private Vector2 getInputNextPoint(Direction direction)
    {
        switch (direction)
        {
            case Direction.RIGHT:
                return _player.Components.NextCellPoint.position + Vector3.right;
            case Direction.LEFT:
                return _player.Components.NextCellPoint.position + Vector3.left;
            case Direction.UP:
                return _player.Components.NextCellPoint.position + Vector3.up;
            case Direction.DOWN:
                return _player.Components.NextCellPoint.position + Vector3.down;
            default:
                return _player.Components.NextCellPoint.position;

        }
    }

}
