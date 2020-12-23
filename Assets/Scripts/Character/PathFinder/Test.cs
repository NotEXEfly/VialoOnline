using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Test : MonoBehaviour
{
    [SerializeField] private Vector3Int startPos;
    [SerializeField] private Vector3Int targetPos;


    public List<Tilemap> obstacleTilemaps;
    private UnityTilemapGrid grid;

    public List<PathFindingNode> path;
    private PathFinder pathFinder = new PathFinder();


    private void Start()
    {
        grid = new UnityTilemapGrid { obstacleMaps = this.obstacleTilemaps };
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log($"KEy down");
            
            //this.path = PathFinder.CompressPath(this.path);
        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            Debug.Log("KEy UP");
            foreach (PathFindingNode item in path)
            {
                Debug.Log($"X = {item.x}, Y = {item.y}");
            }
        }
    }

}
