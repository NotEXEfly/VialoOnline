using UnityEngine;

public class CharacterActions
{
    private Character _character;
    protected CellMovement _cellMovement;

    public CharacterActions(Character character)
    {
        _character = character;
        _cellMovement = new CellMovement(_character.Components.RigitBody, _character.Components.NextCellPoint, _character.Stats.Speed);
    }

    public virtual void Move()
    {
        _cellMovement.MoveToNextCell();

        //animations
        if (_cellMovement.IsMoves)
        {
            Vector2 targetMovePos = new Vector2(_character.Components.NextCellPoint.position.x, _character.Components.NextCellPoint.position.y);
            Vector2 playerRBPos = new Vector2(_character.Components.RigitBody.position.x, _character.Components.RigitBody.position.y);
            PlayMoveAnimations(targetMovePos, playerRBPos);
        }
        else
        {
            PlayIdleAnimations(_character.Stats.ViewDirection);
        }
    }

    public virtual void Attack()
    {
        // _character.Components.Animator.TryPlayAnimation("Attack");
    }

    public virtual void MoveByPath(Vector2Int targetCell) { }

    protected Vector2Int GetPointFromDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.RIGHT:
                return Vector2Int.CeilToInt(_character.Components.NextCellPoint.position + Vector3.right);
            case Direction.LEFT:
                return Vector2Int.CeilToInt(_character.Components.NextCellPoint.position + Vector3.left);
            case Direction.UP:
                return Vector2Int.CeilToInt(_character.Components.NextCellPoint.position + Vector3.up);
            case Direction.DOWN:
                return Vector2Int.CeilToInt(_character.Components.NextCellPoint.position + Vector3.down);
            default:
                return Vector2Int.CeilToInt(_character.Components.NextCellPoint.position);

        }
    }
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

    protected void PlayIdleAnimations(Direction lastViewDirection)
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
