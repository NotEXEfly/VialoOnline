using UnityEngine;

public static class MoveDirection
{
    public static Direction FromZero(Vector2 input)
    {
        if (input == Vector2.zero)
        {
            return Direction.NONE;
        }

        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            if (input.x > 0)
                return Direction.RIGHT;
            else
                return Direction.LEFT;
        }
        else
        {
            if (input.y > 0)
                return Direction.UP;
            else
                return Direction.DOWN;
        }
    }

    public static Direction FromNextPoint(Vector2 nextPoint, Character character)
    {
        var characterPosition = character.Components.RealPosition.position;
        var difference = nextPoint - new Vector2(characterPosition.x, characterPosition.y);
        return FromZero(difference);
    }

    public static Vector2Int GetPoint(Direction direction, Character character)
    {
        Vector3 characterPosition = character.Components.RealPosition.position;
        switch (direction)
        {
            case Direction.RIGHT:
                return Vector2Int.CeilToInt(characterPosition + Vector3.right);
            case Direction.LEFT:
                return Vector2Int.CeilToInt(characterPosition + Vector3.left);
            case Direction.UP:
                return Vector2Int.CeilToInt(characterPosition + Vector3.up);
            case Direction.DOWN:
                return Vector2Int.CeilToInt(characterPosition + Vector3.down);
            default:
                return Vector2Int.CeilToInt(characterPosition);
        }
    }
}
