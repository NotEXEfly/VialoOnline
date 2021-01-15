using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    [Range(0, 3)]
    [SerializeField] private float _waitBtwSteps = 1;
    public float WaitBtwSteps { get => _waitBtwSteps; }

    private EnemyActions _actions;

    private void Start()
    {
        _actions = new EnemyActions(this);

        _components.RealPosition.parent = null;

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

    private void FixedUpdate()
    {
        _actions.Move();
    }
}
