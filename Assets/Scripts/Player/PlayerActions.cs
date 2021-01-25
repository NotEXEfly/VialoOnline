using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : CharacterActions
{
    private Player _player;
    private PlayerGridMovement _gridMovement;

    public PlayerGridMovement GridMovement { get => _gridMovement; set => _gridMovement = value; }

    public PlayerActions(Player player) : base (player) 
    {
        _player = player;
        _gridMovement = new PlayerGridMovement(_player, _player.Components.ObstacleTilemaps);
    }

    public void SelectCellPoint()
    {
        // idle animation direction on stay
        if (CellMovement.IsReadyMove && _player.Utilities.InputDirection != Direction.NONE)
            _player.Stats.ViewDirection = _player.Utilities.InputDirection;

        // wasd/joystick movement
        if (CellMovement.IsReadyMove)
        {
            if (_player.Utilities.InputDirection != Direction.NONE)
            {
                GridMovement.MoveCharacterTo(_player.Utilities.InputDirection);
            }
        }

        // move to next point from list
        if (CellMovement.IsReadyMove)
        {
            GridMovement.SetNextPoint();
        }
    }

    public override void MoveByPath(Vector2Int targetCell)
    {
        bool targetWalkable = GridMovement.TilemapGrid.IsWalkable(targetCell.x, targetCell.y);

        if (targetWalkable)
        {
            var newPath = GridMovement.BuildPath(targetCell);
            GridMovement.SetNewPath(newPath);   
        }
        else
        {
            //var newPath = GridMovement.BuildPath(targetCell, true);
            //GridMovement.SetNewPath(newPath);

            //var neighbours = _gridMovement.PathFinder.GetNeighbours(new PathFindingNode(targetCell.x, targetCell.y));
            //foreach (var neighbour in neighbours)
            //{
            //    if (_gridMovement.TilemapGrid.IsWalkable(neighbour.x, neighbour.y))
            //    {
            //        var newPath = _gridMovement.BuildPath(new Vector2Int(neighbour.x, neighbour.y));

            //        if (newPath.Count != 0)
            //        {
            //            _gridMovement.SetNewPath(newPath);

            //            List<Vector2Int> list = new List<Vector2Int>();
            //            list.AddRange(_gridMovement.CurrentPath);
            //            var lastPoint = list[list.Count - 1];
            //            Debug.Log(lastPoint - targetCell);

            //            _gridMovement.CurrentPath.Enqueue(targetCell);

            //            break;
            //        }

            //        break;
            //    }
            //    else
            //    {

            //    }
            //}
        }
        //Direction lastDirection(Vector2Int prevPoint, Vector2Int lastPoint)
        //{
        //    Vector2Int difference = lastPoint - prevPoint;
        //    if (difference.x == 0)
        //    {
        //        if (difference.y == 1)
        //            return Direction.DOWN;
        //        else
        //            return Direction.UP;
        //    }
        //    else
        //    {
        //        if (difference.y == 1)
        //        { 
                    
        //        }
        //    }
        //}
    }
}
