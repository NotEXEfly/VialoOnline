using System.Collections.Generic;
using UnityEngine;

public class CellMovement
{
    public bool IsMoves { get; private set; }
    public bool IsReadyMove { get; private set; }

    private Rigidbody2D _characterRB;
    private Transform _targetCell;
    private float _speed;

    public CellMovement(Rigidbody2D characterRB, Transform targetCell, float speed)
    {
        _characterRB = characterRB;
        _targetCell = targetCell;
        _speed = speed;
    }

    public void MoveToNextCell()
    {
        IsMoves = Vector2.Distance(_characterRB.position, _targetCell.position) != 0;

        if (Vector2.Distance(_characterRB.position, _targetCell.position) <= .05f)
        {
            //fix animation transition
            _characterRB.position = new Vector2(_targetCell.position.x, _targetCell.position.y);
            IsReadyMove = true;
        }
        else
        {
            IsReadyMove = false;
        }
            

        if (IsMoves)
        {
            Vector2 newPosition = Vector2.MoveTowards(_characterRB.position, _targetCell.position, _speed * Time.deltaTime);
            _characterRB.MovePosition(newPosition);
        }
    }
}
