using UnityEngine;

public class PlayerActions
{
    private Player _player;

    public PlayerActions(Player player)
    {
        _player = player;
    }

    public void Move(Transform transform)
    {
        float targetMovePosX = _player.Components.GridMovePoint.position.x;
        float targetMovePosY = _player.Components.GridMovePoint.position.y;

        float playerRBPosX = _player.Components.RigitBody.position.x;
        float playerRBPosY = _player.Components.RigitBody.position.y;

        if (Vector2.Distance(_player.Components.RigitBody.position, _player.Components.GridMovePoint.position) != 0)
        {
            Vector2 newPosition = Vector2.MoveTowards(_player.Components.RigitBody.position, _player.Components.GridMovePoint.position, _player.Stats.Speed * Time.deltaTime);
            _player.Components.RigitBody.MovePosition(newPosition);
            playMoveAnimations();
        }
        else
        {
            _player.Components.Animator.TryPlayAnimation("Idle");
        }

        // Move GridMovePoint on next cell
        // .05f fix micro freezes every cell
        if (Vector2.Distance(_player.Components.RigitBody.position, _player.Components.GridMovePoint.position) <= .05f)
        {
            //fix animation transition
            _player.Components.RigitBody.position = new Vector2(targetMovePosX, targetMovePosY);

            if (Mathf.Abs(_player.Stats.Direction.x) >= 1f)
            {
                if (!Physics2D.OverlapCircle(_player.Components.GridMovePoint.position + new Vector3(_player.Stats.Direction.x, 0f, 0f), .2f, _player.Components.WhatStopMovement))
                {
                    _player.Components.GridMovePoint.position += new Vector3(_player.Stats.Direction.x, 0f, 0f);
                }
            }
            else if (Mathf.Abs(_player.Stats.Direction.y) >= 1f)
            {
                if (!Physics2D.OverlapCircle(_player.Components.GridMovePoint.position + new Vector3(0f, _player.Stats.Direction.y, 0f), .2f, _player.Components.WhatStopMovement))
                {
                    _player.Components.GridMovePoint.position += new Vector3(0f, _player.Stats.Direction.y, 0f);
                }
            }     
        }

        void playMoveAnimations()
        {
            if (targetMovePosX > playerRBPosX)
                _player.Components.Animator.TryPlayAnimation("MoveRight");
            else if (targetMovePosX < playerRBPosX)
                _player.Components.Animator.TryPlayAnimation("MoveLeft");
            if (targetMovePosY > playerRBPosY)
                _player.Components.Animator.TryPlayAnimation("MoveUp");
            else if (targetMovePosY < playerRBPosY)
                _player.Components.Animator.TryPlayAnimation("MoveDown");
        }
    }

    public void Attack()
    {
        _player.Components.Animator.TryPlayAnimation("Attack");
    }
}
