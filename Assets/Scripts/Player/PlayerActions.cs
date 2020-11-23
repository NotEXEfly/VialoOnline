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

        if (Vector2.Distance(_player.Components.RigitBody.position ,_player.Components.GridMovePoint.position) <= .05f)
        {
            if (Mathf.Abs(_player.Stats.Direction.x) >= 0.5f)
            {
                _player.Components.GridMovePoint.position += new Vector3(_player.Stats.Direction.x, 0f, 0f);
            }
            else if (Mathf.Abs(_player.Stats.Direction.y) >= 0.5f)
            {
                _player.Components.GridMovePoint.position += new Vector3(0f, _player.Stats.Direction.y, 0f);
            }

            _player.Components.Animator.TryPlayAnimation("Idle");
        }
        
        if(newPosition != _player.Components.RigitBody.position)
            _player.Components.Animator.TryPlayAnimation("Run");
        

        //flip x
        if (_player.Stats.Direction.x != 0)
        {
            transform.localScale = new Vector2(_player.Stats.Direction.x < 0 ? -1 : 1, 1);
        }


        //_player.Components.RigitBody.velocity = new Vector2(_player.Stats.Direction.x * _player.Stats.Speed * Time.deltaTime, _player.Stats.Direction.y * _player.Stats.Speed * Time.deltaTime);



        //if (_player.Components.RigitBody.velocity == Vector2.zero)
        //{
        //    _player.Components.Animator.TryPlayAnimation("Idle");
        //}
    }

    public void Attack()
    {
        _player.Components.Animator.TryPlayAnimation("Attack");
    }
}
