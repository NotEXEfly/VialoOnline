using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private void Start()
    {
        _actions = new CharacterActions(this);

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

        CreatePath(_actions.PathFinder);
    }

    private void CreatePath(PathFinder pf)
    {
        pf.CurrentPath.Enqueue(new Vector2(8, 0));
        pf.CurrentPath.Enqueue(new Vector2(9, 0));
        pf.CurrentPath.Enqueue(new Vector2(10, 0));

        pf.CurrentPath.Enqueue(new Vector2(10, -1));
        pf.CurrentPath.Enqueue(new Vector2(10, -2));
        pf.CurrentPath.Enqueue(new Vector2(10, -3));

        pf.CurrentPath.Enqueue(new Vector2(9, -3));
        pf.CurrentPath.Enqueue(new Vector2(8, -3));
        pf.CurrentPath.Enqueue(new Vector2(7, -3));

        pf.CurrentPath.Enqueue(new Vector2(7, -2));
        pf.CurrentPath.Enqueue(new Vector2(7, -1));
        pf.CurrentPath.Enqueue(new Vector2(7, 0));
    }
}
