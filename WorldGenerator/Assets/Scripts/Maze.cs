using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [System.Serializable]
    public class Cell
    {
        public bool visited;
        public GameObject north;//1
        public GameObject east;//2
        public GameObject west;//3
        public GameObject south;//4
    }
    
    public GameObject wall;
    private GameObject _wallHolder;
    
    public int xSize = 5;
    public int ySize = 5;

    public float wallLength = 1;

    private Vector3 _initialPos;

    private Cell[] _cells;

    public int currentCell;
    private int _totalCells;

    private int _visitedCells;
    private bool _startedBuilding;

    private int _currentNeighbour;

    private List<int> _lastCell;
    private int _backingUp = 0;

    private int _wallToBreak = 0;

    public GameObject floor;
    public GameObject ceiling;

    public GameObject mapCamera;

    public GameObject player;

    public GameObject coinPrefab;
    public int numberOfCoins = -1;

    private SpawnRoom _spawnRoomScript;
    
    // Start is called before the first frame update
    void Start()
    {
        //xSize = Random.Range(6, 20);
        //ySize = Random.Range(6, 20);
        xSize = MenuScript.globalXValue;
        ySize = MenuScript.globalYValue;
        
        numberOfCoins = -1;
        
        CreateWalls();

        var floorX = (float)xSize / 10;
        var floorY = (float)ySize / 10;
        var mapHeight = Mathf.Max(xSize, ySize);
        float offsetX = 0;
        float offsetY = 0;
        offsetX = xSize % 2 == 0 ? 0 : 0.5f;
        offsetY = ySize % 2 == 0 ? -0.5f : 0;
        
        floor.transform.localScale = new Vector3(floorX, 1, floorY);
        ceiling.transform.localScale = new Vector3(floorX, 1, floorY);
        
        floor.transform.position = new Vector3(offsetX, -0.5f, offsetY);
        ceiling.transform.position = new Vector3(offsetX, 0.5f, offsetY);
        
        mapCamera.transform.position = new Vector3(offsetX, mapHeight, offsetY);
        
        _spawnRoomScript = GameObject.FindGameObjectWithTag("Spawn").GetComponent<SpawnRoom>();
    }

    void CreateWalls()
    {
        GameObject tempWall;

        _wallHolder = new GameObject {name = "Maze"};


        _initialPos = new Vector3((-xSize / 2) + wallLength / 2, 0, (-ySize / 2) + wallLength / 2);
        var myPos = _initialPos;
        
        // X axis
        for (var i = 0; i < ySize; i++)
        {
            for (var o = 0; o <= xSize; o++)
            {
                myPos = new Vector3(_initialPos.x + (o * wallLength) - wallLength / 2, 0,
                    _initialPos.z + (i * wallLength) - wallLength / 2);

                tempWall = Instantiate(wall, myPos, Quaternion.identity) as GameObject;

                tempWall.transform.parent = _wallHolder.transform;
            }
        }
        
        // Y axis
        for (var i = 0; i <= ySize; i++)
        {
            for (var o = 0; o < xSize; o++)
            {
                myPos = new Vector3(_initialPos.x + (o * wallLength), 0,
                    _initialPos.z + (i * wallLength) - wallLength);

                tempWall = Instantiate(wall, myPos, Quaternion.Euler(0, 90, 0)) as GameObject;
                
                tempWall.transform.parent = _wallHolder.transform;
            }
        }

        CreateCells();
    }

    void CreateCells()
    {
        _lastCell = new List<int>();
        _lastCell.Clear();
        _totalCells = xSize * ySize;
        var children = _wallHolder.transform.childCount;
        var allWalls = new GameObject[children];
        _cells = new Cell[xSize * ySize];
        var eastWestProcess = 0;
        var childProcess = 0;
        var termCount = 0;
        
        for (var i = 0; i < children; i++)
        {
            allWalls[i] = _wallHolder.transform.GetChild(i).gameObject;
        }

        for (var cellProcess = 0; cellProcess < _cells.Length; cellProcess++)
        {
            _cells[cellProcess] = new Cell
            {
                west = allWalls[eastWestProcess], south = allWalls[childProcess + (xSize + 1) * ySize]
            };


            if (termCount == xSize)
            {
                eastWestProcess += 2;
                termCount = 0;
            }
            else
            {
                eastWestProcess++;
            }

            termCount++;
            childProcess++;
            
            _cells[cellProcess].east = allWalls[eastWestProcess];
            _cells[cellProcess].north = allWalls[(childProcess + (xSize + 1) * ySize) + xSize - 1];
        }

        CreateMaze();
    }

    void CreateMaze()
    {
        if (_visitedCells < _totalCells)
        {
            if (_startedBuilding)
            {
                GiveNeighbour();
                if (_cells[_currentNeighbour].visited == false && _cells[currentCell].visited == true)
                {
                    BreakWall();
                    _cells[_currentNeighbour].visited = true;
                    _visitedCells++;
                    _lastCell.Add(currentCell);
                    currentCell = _currentNeighbour;
                    if (_lastCell.Count > 0)
                    {
                        _backingUp = _lastCell.Count - 1;
                    }
                }
            }
            else
            {
                currentCell = Random.Range(0, _totalCells);
                _cells[currentCell].visited = true;
                _visitedCells++;
                _startedBuilding = true;
            }
            
            Invoke(nameof(CreateMaze), 0);
            
        }
        else
        {
            numberOfCoins = Random.Range(0, (xSize * ySize)/2);
            var xRange = xSize / 2 - 1;
            var yRange = ySize / 2 - 1;

            for (int i = 0; i < numberOfCoins; i++)
            {
                Instantiate(coinPrefab, new Vector3(Random.Range(-xRange, xRange) + 0.5f, 0, Random.Range(-yRange, yRange)), Quaternion.identity);
            }
            
            _spawnRoomScript.DestroySpawn();
        }
    }

    void BreakWall()
    {
        switch (_wallToBreak)
        {
            case 1 : Destroy(_cells[currentCell].north); break;
            case 2 : Destroy(_cells[currentCell].east); break;
            case 3 : Destroy(_cells[currentCell].west); break;
            case 4 : Destroy(_cells[currentCell].south); break;
        }
    }

    void GiveNeighbour()
    {
        var length = 0;
        int[] neighbours = new int[4];
        
        int[] connectingWall = new int[4];
        
        var check = 0;
        check = (currentCell + 1) / xSize;
        check -= 1;
        check *= xSize;
        check += xSize;
        
        // west
        if (currentCell - 1 >= 0 && currentCell != check)
        {
            if (_cells[currentCell - 1].visited == false)
            {
                neighbours[length] = currentCell - 1;
                connectingWall[length] = 3;
                length++;
            }
        }
        // east
        if (currentCell + 1 < _totalCells && (currentCell + 1) != check)
        {
            if (_cells[currentCell + 1].visited == false)
            {
                neighbours[length] = currentCell + 1;
                connectingWall[length] = 2;
                length++;
            }
        }
        // north
        if (currentCell + xSize < _totalCells)
        {
            if (_cells[currentCell + xSize].visited == false)
            {
                neighbours[length] = currentCell + xSize;
                connectingWall[length] = 1;
                length++;
            }
        }
        // south
        if (currentCell - xSize >= 0)
        {
            if (_cells[currentCell - xSize].visited == false)
            {
                neighbours[length] = currentCell - xSize;
                connectingWall[length] = 4;
                length++;
            }
        }

        if (length != 0)
        {
            var chosenOne = Random.Range(0, length);
            _currentNeighbour = neighbours[chosenOne];

            _wallToBreak = connectingWall[chosenOne];
        }
        else
        {
            if (_backingUp <= 0) return;
            currentCell = _lastCell[_backingUp];
            _backingUp--;
        }
    }
}
