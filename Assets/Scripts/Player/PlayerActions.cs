using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : CharacterActions
{
    private Player _player;
    private PlayerGridMovement _gridMovement;
    private Direction _lastViewDirection = Direction.DOWN;

    public PlayerActions(Player player) : base (player) 
    {
        _player = player;
        _gridMovement = new PlayerGridMovement(_player.Components.NextCellPoint, _player.Components.ObstacleTilemaps);
    }

    public override void Move()
    {
        //btw cell movemet
        base.Move();

        // idle animation direction on stay
        if (_player.Utilities.InputDirection != Direction.NONE)
            _lastViewDirection = _player.Utilities.InputDirection;

        if (!_cellMovement.IsMoves)
            PlayIdleAnimations(_lastViewDirection);

        // grid movement
        if (_cellMovement.IsReadyMove)
        {
            if (_player.Utilities.InputDirection != Direction.NONE)
            {
                _gridMovement.SetNextPoint(GetPointFromDirection(_player.Utilities.InputDirection));
            }
        }

        if (_cellMovement.IsReadyMove && _gridMovement.CurrentPath.Count != 0)
        {
            _player.Components.NextCellPoint.position = _gridMovement.GetNextPoint();
        }

    }

    public override void Attack()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int targetPos = new Vector2Int(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));
        _gridMovement.SetNewPath(targetPos);
    }

}
