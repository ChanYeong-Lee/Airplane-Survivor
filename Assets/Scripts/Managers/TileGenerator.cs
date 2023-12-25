using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class TileGenerator : MonoBehaviour
{
    public GameObject tilePrefab;
    public float tileSize;
    public Transform tilesParent;
    public int borderDistance;
    public int removeDistance;


    private Transform player;
    public List<Vector2Int> tiledCells = new List<Vector2Int>();
    public List<GameObject> tiledObjects = new List<GameObject>();
    public Vector2Int playerCell;

    private Vector2Int[] directionCells = new Vector2Int[]
    {
        Vector2Int.up,
        Vector2Int.down,
        Vector2Int.left,
        Vector2Int.right
    };

    private void Start()
    {
        player = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        playerCell = PosToCell(player.position);
        for (int x = playerCell.x - borderDistance; x <= playerCell.x + borderDistance; x++)
        {
            for (int y = playerCell.y - borderDistance; y <= playerCell.y + borderDistance; y++)
            {
                GenerateTile(new Vector2Int(x, y));
            }
        }
        RemoveTile(playerCell);
        
    }

    private Vector2Int PosToCell(Vector2 pos)
    {
        int cellX = (int)(pos.x / tileSize);
        int cellY = (int)(pos.y / tileSize);
        return new Vector2Int(cellX, cellY);
    }

    private Vector2 CellToPos(Vector2Int cell)
    {
        float posX = cell.x * tileSize;
        float posY = cell.y * tileSize;
        return new Vector2(posX, posY);
    }
    private void GenerateTile(Vector2Int cell)
    {
        if (tiledCells.Contains(cell))
        {
            return;
        }

        Vector2 pos = CellToPos(cell);
        GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
        tile.transform.parent = tilesParent;
        tiledCells.Add(cell);
        tiledObjects.Add(tile);
    }

    private void RemoveTile(Vector2Int cell)
    {
        List<GameObject> removeObjects = new List<GameObject>();
        foreach (GameObject tiledObject in tiledObjects)
        {
            Vector2Int targetCell = PosToCell(tiledObject.transform.position);
            Vector2Int sqr = playerCell - targetCell;
            if (Mathf.Abs(sqr.x) >= removeDistance || Mathf.Abs(sqr.y) >= removeDistance)
            {
                removeObjects.Add(tiledObject);
                tiledCells.Remove(targetCell);
            }
        }
        foreach (GameObject removeObject in removeObjects)
        {
            tiledObjects.Remove(removeObject);
            Destroy(removeObject);
        }
    }
}
