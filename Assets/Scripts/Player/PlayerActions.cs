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
        Vector2 newPosition = Vector2.MoveTowards(_player.Components.RigitBody.position, _player.Components.GridMovePoint.position, _player.Stats.Speed * Time.deltaTime);
        _player.Components.RigitBody.MovePosition(newPosition);

        if (Vector2.Distance(_player.Components.RigitBody.position, _player.Components.GridMovePoint.position) <= .05f)
        {
            if (Mathf.Abs(_player.Stats.Direction.x) >= 1f)
            {
                if(!Physics2D.OverlapCircle(_player.Components.GridMovePoint.position + new Vector3(_player.Stats.Direction.x, 0f, 0f), .2f, _player.Components.WhatStopMovement))
                    _player.Components.GridMovePoint.position += new Vector3(_player.Stats.Direction.x, 0f, 0f);
            }
            else if (Mathf.Abs(_player.Stats.Direction.y) >= 1f)
            {
                if (!Physics2D.OverlapCircle(_player.Components.GridMovePoint.position + new Vector3(0f, _player.Stats.Direction.y, 0f), .2f, _player.Components.WhatStopMovement))
                    _player.Components.GridMovePoint.position += new Vector3(0f, _player.Stats.Direction.y, 0f);
            }
            else 
            {
                _player.Components.Animator.TryPlayAnimation("Idle");
            }         
        }
        else 
        {
            if (newPosition.x > _player.Components.RigitBody.position.x)
                _player.Components.Animator.TryPlayAnimation("MoveRight");
            else if(newPosition.x < _player.Components.RigitBody.position.x)
                _player.Components.Animator.TryPlayAnimation("MoveLeft");
            else if (newPosition.y > _player.Components.RigitBody.position.y)
                _player.Components.Animator.TryPlayAnimation("MoveUp");
            else if (newPosition.y < _player.Components.RigitBody.position.y)
                _player.Components.Animator.TryPlayAnimation("MoveDown");
        }
        


        //flip x
        //if (_player.Stats.Direction.x != 0)
        //{
        //    transform.localScale = new Vector2(_player.Stats.Direction.x < 0 ? -1 : 1, 1);
        //}

    }

    public void Attack()
    {
        _player.Components.Animator.TryPlayAnimation("Attack");
    }
}
