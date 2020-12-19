using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private void Start()
    {
        _actions = new EnemyActions(this);

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

    private void CreatePath(BaseGridMovement gm)
    {
        gm.CurrentPath.Enqueue(new Vector2(8, 0));
        gm.CurrentPath.Enqueue(new Vector2(9, 0));
        gm.CurrentPath.Enqueue(new Vector2(10, 0));

        gm.CurrentPath.Enqueue(new Vector2(10, -1));
        gm.CurrentPath.Enqueue(new Vector2(10, -2));
        gm.CurrentPath.Enqueue(new Vector2(10, -3));

        gm.CurrentPath.Enqueue(new Vector2(9, -3));
        gm.CurrentPath.Enqueue(new Vector2(8, -3));
        gm.CurrentPath.Enqueue(new Vector2(7, -3));

        gm.CurrentPath.Enqueue(new Vector2(7, -2));
        gm.CurrentPath.Enqueue(new Vector2(7, -1));
        gm.CurrentPath.Enqueue(new Vector2(7, 0));
    }
}
