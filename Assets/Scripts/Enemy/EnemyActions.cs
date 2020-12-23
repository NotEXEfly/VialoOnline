using UnityEngine;

public class EnemyActions : CharacterActions
{
    private Enemy _enemy;
    private float _waitBtwStepsTimer;
    private EnemyGridMovement _gridMovement;
    public EnemyGridMovement GridMovement { get => _gridMovement; }

    private System.Random _rnd = new System.Random();
    private Direction _lastDirection;

    public EnemyActions(Enemy enemy) : base (enemy)
    {
        _enemy = enemy;
       _gridMovement = new EnemyGridMovement(enemy.Components.NextCellPoint, enemy.Components.ObstacleTilemaps);
    }

    

    public override void Move()
    {
        //btw cell movemet
        base.Move();

        // grid movement
        if (_cellMovement.IsReadyMove)
        {
            Direction randDirection = (Direction)_rnd.Next(0, 4);

             _gridMovement.SetNextPoint(GetPointFromDirection(randDirection));

            //_lastDirection = randDirection;
        }

        if (_cellMovement.IsReadyMove && _gridMovement.CurrentPath.Count != 0)
        {
            //_enemy.Components.NextCellPoint.position = _gridMovement.GetNextPoint();

            _waitBtwStepsTimer += Time.deltaTime;
            if ((_enemy.WaitBtwSteps >= 0f) && (_enemy.WaitBtwSteps <= _waitBtwStepsTimer))
            {
                _enemy.Components.NextCellPoint.position = _gridMovement.GetNextPoint();
                _waitBtwStepsTimer = 0f;
            }
        }
    }
}
