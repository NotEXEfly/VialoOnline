using UnityEngine;

public class MoveCommand : Command
{

    private Player _player;

    public MoveCommand(Player player, KeyCode key) : base(key)
    {
        _player = player;
    }

    public override void GetKeyDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int targetPos = new Vector2Int(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));

        _player.Actions.MoveByPath(targetPos);
    }
}
