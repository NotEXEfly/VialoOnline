using System.Collections.Generic;
using UnityEngine;

public class PlayerUtilities
{
    private Player _player;

    private List<Command> _commands = new List<Command>();

    public PlayerUtilities(Player player)
    {
        _player = player;
        _commands.Add(new AttackCommand(_player, KeyCode.E));
    }

    public void HandleInput()
    {
        _player.Stats.Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

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
