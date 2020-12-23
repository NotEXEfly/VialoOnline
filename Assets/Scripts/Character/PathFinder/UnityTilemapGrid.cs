using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnityTilemapGrid : IPathFindingGrid
{
	public List<Tilemap> obstacleMaps;

	public bool IsWalkable(int x, int y)
	{
		foreach (Tilemap om in obstacleMaps)
		{
			if (om.GetTile(new Vector3Int(x - 1, y - 1, 0)))
			{
				return false;
			}
		}

		return true;
	}
}
