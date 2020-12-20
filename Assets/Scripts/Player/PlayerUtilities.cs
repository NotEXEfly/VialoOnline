using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
    private Player _player;
    private Joystick _joystick;
    private Vector2 _input;

    public float AxisRawInput { get; set; }
    public Direction InputDirection { get; private set; } = Direction.NONE;

    public PlayerUtilities(Player player, Joystick joystick)
    {
        _player = player;
        _joystick = joystick;
    }

    public void HandleInput()
    {
#if UNITY_EDITOR
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#else
        _input = _joystick.Direction;
#endif

        SetInputDirection(_input);
    }

    
    private void SetInputDirection(Vector2 input)
    {
        if (input == Vector2.zero)
        {
            InputDirection = Direction.NONE;
            return;
        }


        if (Mathf.Abs(input.x) > Mathf.Abs(input.y))
        {
            if (input.x > 0)
                InputDirection = Direction.RIGHT;
            else
                InputDirection = Direction.LEFT;
        }
        else
        {
            if (input.y > 0)
                InputDirection = Direction.UP;
            else
                InputDirection = Direction.DOWN;
        }
    }
}
