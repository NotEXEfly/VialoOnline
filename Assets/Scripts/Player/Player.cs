using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private PlayerUtilities _utilities;
    [SerializeField]private Joystick _joystick;
    public PlayerUtilities Utilities { get => _utilities; }
    public Joystick Joystick { get => _joystick;}

    private void Start()
    {
        _actions = new CharacterActions(this);
        _utilities = new PlayerUtilities(this, _joystick);

        _components.NextCellPoint.parent = null;

        AnyStateAnimation[] animations = new AnyStateAnimation[]
{
            new AnyStateAnimation(RIG.BODY, "IdleRight"),
            new AnyStateAnimation(RIG.BODY, "IdleLeft"),
            new AnyStateAnimation(RIG.BODY, "IdleUp"),
            new AnyStateAnimation(RIG.BODY, "IdleDown"),

            new AnyStateAnimation(RIG.BODY, "MoveRight"),
            new AnyStateAnimation(RIG.BODY, "MoveLeft"),
            new AnyStateAnimation(RIG.BODY, "MoveUp"),
            new AnyStateAnimation(RIG.BODY, "MoveDown"),

            new AnyStateAnimation(RIG.BODY, "Attack"),
};
        _components.Animator.AddAnimations(animations);
    }


    private void Update()
    {
        _utilities.HandleInput();
    }
}
