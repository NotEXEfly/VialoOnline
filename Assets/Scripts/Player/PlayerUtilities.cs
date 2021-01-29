using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
    private Player _player;
    private Joystick _joystick;
    private Vector2 _input;

    public Direction InputDirection { get; private set; } = Direction.NONE;

    public PlayerUtilities(Player player, Joystick joystick)
    {
        _player = player;
        _joystick = joystick;
    }

    public void HandleInput()
    {
        // movement joystick
#if UNITY_EDITOR
        _input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _input = _joystick.Direction;
#else
        _input = _joystick.Direction;
#endif
        InputDirection = MoveDirection.FromZero(_input);
    }
}
