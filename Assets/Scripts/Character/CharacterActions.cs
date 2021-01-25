using UnityEngine;

public abstract class CharacterActions
{
    public CellMovement CellMovement => _cellMovement;

    private Character _character;
    private CellMovement _cellMovement;

    public CharacterActions(Character character)
    {
        _character = character;
        _cellMovement = new CellMovement(_character.Components.RigitBody, _character.Components.RealPosition, _character.Stats.Speed);
    }

    public void Move()
    {
        CellMovement.MoveToNextCell();
        //animations
        if (CellMovement.IsMoves)
        {
            Vector2 targetMovePos = new Vector2(_character.Components.RealPosition.position.x, _character.Components.RealPosition.position.y);
            Vector2 playerRBPos = new Vector2(_character.Components.RigitBody.position.x, _character.Components.RigitBody.position.y);
            PlayMoveAnimations(targetMovePos, playerRBPos);
        }
        else
        {
            PlayIdleAnimations(_character.Stats.ViewDirection);
        }
    }

    public virtual void MoveByPath(Vector2Int targetCell) { }

    // ------------------------ ANIMATIONS -----------------------------
    private void PlayMoveAnimations(Vector2 targetMovePos, Vector2 playerRBPos)
    {
        if (targetMovePos.x > playerRBPos.x)
        {
            _character.Components.Animator.TryPlayAnimation("MoveRight");
            _character.Stats.ViewDirection = Direction.RIGHT;
        }

        else if (targetMovePos.x < playerRBPos.x)
        {
            _character.Components.Animator.TryPlayAnimation("MoveLeft");
            _character.Stats.ViewDirection = Direction.LEFT;
        }

        if (targetMovePos.y > playerRBPos.y)
        {
            _character.Components.Animator.TryPlayAnimation("MoveUp");
            _character.Stats.ViewDirection = Direction.UP;
        }

        else if (targetMovePos.y < playerRBPos.y)
        {
            _character.Components.Animator.TryPlayAnimation("MoveDown");
            _character.Stats.ViewDirection = Direction.DOWN;
        }

    }

    private void PlayIdleAnimations(Direction lastViewDirection)
    {
        switch (lastViewDirection)
        {
            case Direction.RIGHT:
                _character.Components.Animator.TryPlayAnimation("IdleRight");
                break;
            case Direction.LEFT:
                _character.Components.Animator.TryPlayAnimation("IdleLeft");
                break;
            case Direction.UP:
                _character.Components.Animator.TryPlayAnimation("IdleUp");
                break;
            case Direction.DOWN:
                _character.Components.Animator.TryPlayAnimation("IdleDown");
                break;
            default:
                _character.Components.Animator.TryPlayAnimation("IdleDown");
                break;
        }
    }
}
