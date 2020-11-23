using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerStats _stats;
    [SerializeField]
    private PlayerComponents _components;
    private PlayerReferences _references;
    private PlayerUtilities _utilities;
    private PlayerActions _actions;

    public PlayerComponents Components { get => _components;}
    public PlayerStats Stats { get => _stats; }
    public PlayerActions Actions { get => _actions;}
    public PlayerUtilities Utilities { get => _utilities;}

    private void Start()
    {
        _actions = new PlayerActions(this);
        _utilities = new PlayerUtilities(this);

        _components.GridMovePoint.parent = null;

        _stats.Speed = _stats.RunSpeed;

        AnyStateAnimation[] animations = new AnyStateAnimation[]
        {
            new AnyStateAnimation(RIG.BODY, "Idle"),
            new AnyStateAnimation(RIG.BODY, "Run"),
            new AnyStateAnimation(RIG.BODY, "Attack"),
        };

        _components.Animator.AddAnimations(animations);
    }

    private void Update()
    {
        _utilities.HandleInput();
    }

    private void FixedUpdate()
    {
        _actions.Move(transform);
    }
}
