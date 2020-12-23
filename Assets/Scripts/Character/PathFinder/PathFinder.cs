using System.Collections.Generic;
using UnityEngine;

public class PathFinder
{
	private const int MAX_SEEKS = 1000;

	public List<PathFindingNode> foundNodes = new List<PathFindingNode>();
	public List<PathFindingNode> unexploredNodes = new List<PathFindingNode>();
	public PathFindingNode currentNode;
	public IPathFindingGrid grid;
	public int destinationX;
	public int destinationY;

	/// <summary>
	/// Setup the pathfinder for a new seek
	/// </summary>
	/// <param name="grid">The grid to search</param>
	/// <param name="destinationX">Destination x-coord</param>
	/// <param name="destinationY">Destination y-coord</param>
	/// <param name="startX">Start x-coord</param>
	/// <param name="startY">Start y-coord</param>
	public void Set(IPathFindingGrid grid, int startX, int startY, int destinationX, int destinationY)
	{
		this.grid = grid;
		this.destinationX = destinationX;
		this.destinationY = destinationY;
		this.currentNode = new PathFindingNode(startX, startY);
		this.foundNodes.Clear();
		this.unexploredNodes.Clear();
	}

	/// <summary>
	/// Seek a path from the start to the destination
	/// </summary>
	/// <returns>Path if possible, otherwise null</returns>
	public List<PathFindingNode> Seek()
	{
		List<PathFindingNode> path = new List<PathFindingNode>();

		if (currentNode == null || grid == null)
		{
			return path;
		}

		if (!grid.IsWalkable(destinationX, destinationY))
		{
			Debug.Log($"{destinationX} {destinationY} not walkable");
			return path;
		}

		if (currentNode.x == destinationX && currentNode.y == destinationY)
		{
			return path;
		}

		foundNodes.Add(currentNode);

		for (int i = 0; i < MAX_SEEKS; i++)
		{
			if (currentNode.x == destinationX && currentNode.y == destinationY)
			{
				path.Add(currentNode);
				PathFindingNode n = currentNode.parent;

				while (n != null)
				{
					path.Add(n);
					n = n.parent;
				}

				// Since we iterate from the end
				// to the start we need to reverse the
				// path to get a logical order
				path.Reverse();
				break;
			}

			SeekNext();
		}

		return path;
	}

	/// <summary>
	/// Seeks the the next highest priority node
	/// </summary>
	private void SeekNext()
	{
		var neighbours = GetNeighbours(currentNode);

		foreach (PathFindingNode neighbour in neighbours)
		{
			// Not walkable, not interesting
			if (!grid.IsWalkable(neighbour.x, neighbour.y))
			{
				continue;
			}

			int deltaX = Mathf.Abs(neighbour.x - destinationX);
			int deltaY = Mathf.Abs(neighbour.y - destinationY);


			// We have already found the neighbour
			if (foundNodes.Contains(neighbour))
			{
				int foundIndex = foundNodes.IndexOf(neighbour);

				// Check if the current path is shorter to the 
				// neighbour than the path previously found
				// if so, update the already found
				if (neighbour.distanceToStart < foundNodes[foundIndex].distanceToStart)
				{
					foundNodes[foundIndex].parent = neighbour.parent;
					foundNodes[foundIndex].distanceToStart = neighbour.distanceToStart;
				}

				continue;
			}



			// Manhattan distance to end
			neighbour.distanceToEnd = deltaX + deltaY;

			foundNodes.Add(neighbour);
			unexploredNodes.Add(neighbour);
		}

		// Sort the unexplored nodes to prioritize exploring 
		// nodes that have shortest distance to start + end
		unexploredNodes.Sort((x, y) => x.distanceToEnd + x.distanceToStart < y.distanceToEnd + y.distanceToStart ? -1 : 1);

		// Pop the next node to explore
		currentNode = unexploredNodes[0];
		unexploredNodes.RemoveAt(0);
	}

	/// <summary>
	/// Returns the neighbours to the node
	/// </summary>
	/// <param name="node">Node to return neighbours for</param>
	/// <returns>A list of neighbours to the node</returns>
	private List<PathFindingNode> GetNeighbours(PathFindingNode node)
	{
		int x = node.x;
		int y = node.y;
		float movementCost = node.distanceToStart + 1f;

		List<PathFindingNode> n = new List<PathFindingNode>
			{
				new PathFindingNode(node, x, y + 1, movementCost), // top
				new PathFindingNode(node, x + 1, y, movementCost), // right
				new PathFindingNode(node, x, y - 1, movementCost), // bottom
				new PathFindingNode(node, x - 1, y, movementCost)  // left
			};

		return n;
	}
}

