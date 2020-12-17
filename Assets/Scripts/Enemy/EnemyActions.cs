using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyActions : CharacterActions
{
    private float _waitBtwStepsTimer;
    public EnemyActions(Character character) : base (character)
    {
       
    }

    public override void GoToNextCell()
    {
        _waitBtwStepsTimer += Time.deltaTime;
        if ((_character.Stats.WaitBtwSteps >= 0f) && (_character.Stats.WaitBtwSteps <= _waitBtwStepsTimer))
        {
            _character.Components.NextCellPoint.position = _gridMovement.GetNextPoint();
            _waitBtwStepsTimer = 0f;
        }
    }
}
