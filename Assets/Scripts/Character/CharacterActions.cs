using UnityEngine;

public class CharacterActions
{
    private Character _character;

    public CharacterActions(Character character)
    {
        _character = character;
    }

    public void Move()
    {
        if (Vector2.Distance(_character.Components.RigitBody.position, _character.Components.NextCellPoint.position) != 0)
        {
            Vector2 newPosition = Vector2.MoveTowards(_character.Components.RigitBody.position, _character.Components.NextCellPoint.position, _character.Stats.Speed * Time.deltaTime);
            _character.Components.RigitBody.MovePosition(newPosition);


            Vector2 targetMovePos = new Vector2(_character.Components.NextCellPoint.position.x, _character.Components.NextCellPoint.position.y);
            Vector2 playerRBPos = new Vector2(_character.Components.RigitBody.position.x, _character.Components.RigitBody.position.y);
            PlayMoveAnimations(targetMovePos, playerRBPos);
        }
        else
        {
            PlayIdleAnimations(_character.Stats.ViewDirection);
        }


        SetNextCell();
    }



    public void Attack()
    {
       // _character.Components.Animator.TryPlayAnimation("Attack");
    }



    protected virtual void SetNextCell()
    {
        // Move GridMovePoint on next cell
        // .05f fix micro freezes every cell
        if (Vector2.Distance(_character.Components.RigitBody.position, _character.Components.NextCellPoint.position) <= .05f)
        {
            //fix animation transition
            _character.Components.RigitBody.position = new Vector2(_character.Components.NextCellPoint.position.x, _character.Components.NextCellPoint.position.y);

            if (Mathf.Abs(_character.Stats.Direction.x) >= 1f)
            {
                if (!Physics2D.OverlapCircle(_character.Components.NextCellPoint.position + new Vector3(_character.Stats.Direction.x, 0f, 0f), .2f, _character.Components.WhatStopMovement))
                {
                    _character.Components.NextCellPoint.position += new Vector3(_character.Stats.Direction.x, 0f, 0f);
                }
            }
            else if (Mathf.Abs(_character.Stats.Direction.y) >= 1f)
            {
                if (!Physics2D.OverlapCircle(_character.Components.NextCellPoint.position + new Vector3(0f, _character.Stats.Direction.y, 0f), .2f, _character.Components.WhatStopMovement))
                {
                    _character.Components.NextCellPoint.position += new Vector3(0f, _character.Stats.Direction.y, 0f);
                }
            }
        }
    }


    // ------------------------ ANIMATIONS -----------------------------
    void PlayMoveAnimations(Vector2 targetMovePos, Vector2 playerRBPos)
    {
        if (targetMovePos.x > playerRBPos.x)
        {
            _character.Components.Animator.TryPlayAnimation("MoveRight");
            _character.Stats.ViewDirection = ViewDirection.RIGHT;
        }

        else if (targetMovePos.x < playerRBPos.x)
        {
            _character.Components.Animator.TryPlayAnimation("MoveLeft");
            _character.Stats.ViewDirection = ViewDirection.LEFT;
        }

        if (targetMovePos.y > playerRBPos.y)
        {
            _character.Components.Animator.TryPlayAnimation("MoveUp");
            _character.Stats.ViewDirection = ViewDirection.UP;
        }

        else if (targetMovePos.y < playerRBPos.y)
        {
            _character.Components.Animator.TryPlayAnimation("MoveDown");
            _character.Stats.ViewDirection = ViewDirection.DOWN;
        }
            
    }

    void PlayIdleAnimations(ViewDirection lastViewDirection)
    {
        switch (lastViewDirection)
        {
            case ViewDirection.RIGHT:
                _character.Components.Animator.TryPlayAnimation("IdleRight");
                break;
            case ViewDirection.LEFT:
                _character.Components.Animator.TryPlayAnimation("IdleLeft");
                break;
            case ViewDirection.UP:
                _character.Components.Animator.TryPlayAnimation("IdleUp");
                break;
            case ViewDirection.DOWN:
                _character.Components.Animator.TryPlayAnimation("IdleDown");
                break;
            default:
                _character.Components.Animator.TryPlayAnimation("IdleDown");
                break;
        }
    }
}
