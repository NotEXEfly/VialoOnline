using UnityEngine;

public class Player : Character
{
    [SerializeField] private Joystick _joystick;

    private PlayerUtilities _utilities;
    public PlayerUtilities Utilities { get => _utilities; }
    

    private void Start()
    {
        _utilities = new PlayerUtilities(this, _joystick);
        _actions = new PlayerActions(this);
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
