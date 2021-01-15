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

    public override void Move()
    {
        //btw cell movemet
        base.Move();

        // idle animation direction on stay
        if (_cellMovement.IsReadyMove && _player.Utilities.InputDirection != Direction.NONE)
            _player.Stats.ViewDirection = _player.Utilities.InputDirection;

        // wasd/joystick movement
        if (_cellMovement.IsReadyMove)
        {
            if (_player.Utilities.InputDirection != Direction.NONE)
            {
                _gridMovement.MoveCharacterTo(_player.Utilities.InputDirection);
            }
        }

        // move to next point from list
        if (_cellMovement.IsReadyMove && _gridMovement.CurrentPath.Count != 0)
        {
            _player.Components.RealPosition.position = _gridMovement.GetNextPoint();
        }
    }

    public override void Attack()
    {
        
    }

    public override void MoveByPath(Vector2Int targetCell)
    {
        bool targetWalkable = _gridMovement.TilemapGrid.IsWalkable(targetCell.x, targetCell.y);

        if (targetWalkable)
        {
            var newPath = _gridMovement.BuildPath(targetCell);
            _gridMovement.SetNewPath(newPath);
        }
        else
        {

            
        }
        //if (!targetWalkable)
        //{
            //var neighbours = GetNeighbours(new PathFindingNode(destinationX, destinationY));
            //bool topIsWalkable = grid.IsWalkable(neighbours[0].x, neighbours[0].y);
            //bool rightIsWalkable = grid.IsWalkable(neighbours[1].x, neighbours[1].y);
            //bool bottomIsWalkable = grid.IsWalkable(neighbours[2].x, neighbours[2].y);
            //bool leftIsWalkable = grid.IsWalkable(neighbours[3].x, neighbours[3].y);
            //foreach (var neighbour in neighbours)
            //{
            //    if (_gridMovement.TilemapGrid.IsWalkable(neighbour.x, neighbour.y))
            //    {
            //        targetCell.x = neighbour.x;
            //        targetCell.y = neighbour.y;
            //        break;
            //    }
            //    else
            //    {
                    
            //    }
            //}
        //}

        
        
    }
}
