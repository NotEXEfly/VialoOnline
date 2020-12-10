using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput
{
    private Character _character;
    private Joystick _joystick;

    public PlayerInput(Character character, Joystick joystick)
    {
        _character = character;
        _joystick = joystick;
    }

    public void HandleInput()
    {
        //_player.Stats.Direction = _joystick.Direction;
        _character.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
}
