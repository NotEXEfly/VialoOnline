using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
    private Player _player;
    private Joystick _joystick;
    private Vector2 _input;

    public float AxisRawInput { get; set; }
    public Direction InputDirection { get; private set; } = Direction.NONE;

    private List<Command> _commands = new List<Command>();

    public PlayerUtilities(Player player, Joystick joystick)
    {
        _player = player;
        _joystick = joystick;
        _commands.Add(new AttackCommand(_player, KeyCode.Mouse1));
        _commands.Add(new MoveCommand(_player, KeyCode.Mouse0));
    }

    public void HandleInput()
    {
        // movement joystick
#if UNITY_EDITOR
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
#else
        _input = _joystick.Direction;
#endif
        SetInputDirection(_input);


        foreach (Command command in _commands)
        {
            if (Input.GetKeyDown(command.Key))
            {
                command.GetKeyDown();
            }

            if (Input.GetKeyUp(command.Key))
            {
                command.GetKeyUp();
            }

            if (Input.GetKey(command.Key))
            {
                command.GetKey();
            }
        }

        //DetectSwipe();
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
