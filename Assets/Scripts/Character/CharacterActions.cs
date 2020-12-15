using UnityEngine;

public class CharacterActions
{
    private Character _character;
    private PathFinder _pathFinder;
    private float _waitBtwStepsTimer;

    public PathFinder PathFinder { get => _pathFinder; set => _pathFinder = value; }

    public CharacterActions(Character character)
    {
        _character = character;
        _pathFinder = new PathFinder(_character.Components.NextCellPoint.position);
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

        // Wait time between steps
        if (ReadyToMove() && _pathFinder.CurrentPath.Count != 0)
        {
            _waitBtwStepsTimer += Time.deltaTime;
            if ((_character.Stats.WaitBtwSteps >= 0f) && (_character.Stats.WaitBtwSteps <= _waitBtwStepsTimer))
            {
                _character.Components.NextCellPoint.position = _pathFinder.GetNextPoint();
                _waitBtwStepsTimer = 0f;
            }
        }

        Cross();


    }

    private void Cross()
    {
        // cross input
        if (ReadyToMove())
        {
            if (Mathf.Abs(_character.Stats.Direction.x) >= 1f)
            {
                if (!Physics2D.OverlapCircle(_character.Components.NextCellPoint.position + new Vector3(_character.Stats.Direction.x, 0f, 0f), .2f, _character.Components.WhatStopMovement))
                {
                    _pathFinder.SetNextPoint(_character.Components.NextCellPoint.position + new Vector3(_character.Stats.Direction.x, 0f));
                    //_character.Components.NextCellPoint.position += new Vector3(_character.Stats.Direction.x, 0f, 0f);
                }
            }
            else if (Mathf.Abs(_character.Stats.Direction.y) >= 1f)
            {
                if (!Physics2D.OverlapCircle(_character.Components.NextCellPoint.position + new Vector3(0f, _character.Stats.Direction.y, 0f), .2f, _character.Components.WhatStopMovement))
                {
                    _pathFinder.SetNextPoint(_character.Components.NextCellPoint.position + new Vector3(0, _character.Stats.Direction.y));
                    //_character.Components.NextCellPoint.position += new Vector3(0f, _character.Stats.Direction.y, 0f);
                }
            }
        }
    }


    public void Attack()
    {
        // _character.Components.Animator.TryPlayAnimation("Attack");
    }


    public bool ReadyToMove()
    {
        if (Vector2.Distance(_character.Components.RigitBody.position, _character.Components.NextCellPoint.position) <= .05f)
        {
            //fix animation transition
            _character.Components.RigitBody.position = new Vector2(_character.Components.NextCellPoint.position.x, _character.Components.NextCellPoint.position.y);
            return true;
        }
        else return false;
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
