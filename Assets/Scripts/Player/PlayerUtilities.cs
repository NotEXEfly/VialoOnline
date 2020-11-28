﻿using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
    private Player _player;

    private Joystick _joystick;

    private List<Command> _commands = new List<Command>();

    public PlayerUtilities(Player player, Joystick joystick)
    {
        _player = player;
        _joystick = joystick;
        _commands.Add(new AttackCommand(_player, KeyCode.E));
    }

    public void HandleInput()
    {
        _player.Stats.Direction = _joystick.Direction;

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
    }

}
