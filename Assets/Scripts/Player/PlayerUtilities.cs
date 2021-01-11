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
#else
        _input = _joystick.Direction;
#endif
        SetInputDirection(_input);

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2Int targetPos = new Vector2Int(Mathf.RoundToInt(mousePos.x), Mathf.RoundToInt(mousePos.y));

            _player.Actions.MoveByPath(targetPos);
        }


        //DetectSwipe();
    }

    public void test()
    { 
        
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
