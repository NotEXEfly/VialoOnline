using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
    public Queue<Vector2> CurrentPath { get; private set; }

    public PathFinder(Vector2 currentPoint)
    {
        CurrentPath = new Queue<Vector2>();
        CurrentPath.Enqueue(currentPoint);
    }

    public Vector2 GetNextPoint()
    {
        return CurrentPath.Dequeue();
    }

    public void SetNextPoint(Vector2 targetPoint)
    {
        CurrentPath.Clear();
        CurrentPath.Enqueue(targetPoint);
    }
}
