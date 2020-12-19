using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : CharacterActions
{
    private Player _player;
    private PlayerGridMovement _gridMovement;

    public PlayerActions(Player player) : base (player) 
    {
        _player = player;
        _gridMovement = new PlayerGridMovement(_player.Components.NextCellPoint.position, _player.Components.SolidTilemap);
    }

    public override void Move()
    {
        //btw cell movemet
        base.Move();


        if (_cellMovement.IsReadyMove)
        {
            if (_player.Utilities.InputDirection != Direction.NONE)
            {
                _gridMovement.SetNextPoint(getInputNextPoint(_player.Utilities.InputDirection));
            }
        }

        if (_cellMovement.IsReadyMove && _gridMovement.CurrentPath.Count != 0)
        {
            _player.Components.NextCellPoint.position = _gridMovement.GetNextPoint();
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
