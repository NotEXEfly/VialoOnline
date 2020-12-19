using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : CharacterActions
{
    private Enemy _enemy;
    private float _waitBtwStepsTimer;
    private EnemyGridMovement _gridMovement;
    public EnemyGridMovement GridMovement { get => _gridMovement; }

    public EnemyActions(Enemy enemy) : base (enemy)
    {
        _enemy = enemy;
       _gridMovement = new EnemyGridMovement(enemy.Components.NextCellPoint.position, enemy.Components.SolidTilemap);
    }

    

    public override void Move()
    {
        //btw cell movemet
        base.Move();


        if (_cellMovement.IsReadyMove && _gridMovement.CurrentPath.Count != 0)
        {
            _waitBtwStepsTimer += Time.deltaTime;
            if ((_enemy.Stats.WaitBtwSteps >= 0f) && (_enemy.Stats.WaitBtwSteps <= _waitBtwStepsTimer))
            {
                _enemy.Components.NextCellPoint.position = _gridMovement.GetNextPoint();
                _waitBtwStepsTimer = 0f;
            }
        }
    }
}
