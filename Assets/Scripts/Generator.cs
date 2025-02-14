using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Cryptography;
using Unity.AI.Navigation;
using UnityEngine;
using Random = UnityEngine.Random;
public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private Cell _MazeCellPrefab;

    
    [SerializeField]
    private int _mazeW;

    [SerializeField]
    private int _mazeD;


    [SerializeField]
    private Cell[,] _mazeGrid;

    public GameObject plane2;

    // Start is called before the first frame update
    void Start()
    {
        _mazeGrid = new Cell[_mazeW, _mazeD];

        for (int i = 0; i < _mazeW; i++)
        {
            for (int j = 0; j < _mazeD; j++)
            {
               _mazeGrid[i,j]=Instantiate(_MazeCellPrefab, new Vector3(i, 0, j), Quaternion.identity, transform);
               _mazeGrid[i, j].transform.localPosition = new Vector3(i, 0, j);
            }
        }
        GenerateMaze(null, _mazeGrid[0, 0]);
        GetComponent<NavMeshSurface>().BuildNavMesh();
        plane2.SetActive(true);
    }

    private void GenerateMaze(Cell previusCell, Cell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previusCell, currentCell);


        Cell nextCell;
        do
        {
            nextCell = GetNextUnvisited(currentCell);
            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);

    }

    private Cell GetNextUnvisited(Cell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

       return unvisitedCells.OrderBy(_=>Random.Range(1,10)).FirstOrDefault();


    }
    private IEnumerable<Cell> GetUnvisitedCells(Cell currentCell)
    {
        int x = (int)currentCell.transform.localPosition.x;
        int z = (int)currentCell.transform.localPosition.z;

        
        if(x-1>=0)
        {
            var cellToL = _mazeGrid[x-1, z];
            if(cellToL.IsVisited == false)
            { 
                yield return cellToL; 
            }
        }
        if (x + 1 < _mazeW)
        {
            var cellToR = _mazeGrid[x + 1, z];
            if(cellToR.IsVisited == false)
            {
                yield return cellToR;
            }
        }
        if(z+1 < _mazeD)
        {
            var cellToF = _mazeGrid[x, z + 1];
            if(cellToF.IsVisited == false) {
                yield return cellToF; 
            }
        }
        if(z-1>=0)
        {
            var cellToB = _mazeGrid[x,z-1];
            if (cellToB.IsVisited == false)
            {
                yield return cellToB;
            }
        }
    }

    private void ClearWalls(Cell previusCell, Cell currentCell)
    {
        if (previusCell == null)
        {
            return;
        }
        if(previusCell.transform.localPosition.x< currentCell.transform.localPosition.x)
        {
            
            previusCell.ClearRightW();
            currentCell.ClearLeftW();
            return;
        }
        if (previusCell.transform.localPosition.x > currentCell.transform.localPosition.x)
        {
            previusCell.ClearLeftW();
            currentCell.ClearRightW();
            return;
        }
        if(previusCell.transform.localPosition.z < currentCell.transform.localPosition.z)
        {
            previusCell.ClearFrontW();
            currentCell.ClearBackW();
            return;
        }
        if (previusCell.transform.localPosition.z > currentCell.transform.localPosition.z)
        {
            previusCell.ClearBackW();
            currentCell.ClearFrontW();
            return;
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
