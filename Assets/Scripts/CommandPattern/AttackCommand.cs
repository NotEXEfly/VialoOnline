using UnityEngine;

public class AttackCommand : Command
{
    private Player _player;

    public AttackCommand(Player player, KeyCode key) : base(key)
    {
        _player = player;
    }

    public override void GetKeyDown()
    {
        _player.Actions.Attack();
    }
}
