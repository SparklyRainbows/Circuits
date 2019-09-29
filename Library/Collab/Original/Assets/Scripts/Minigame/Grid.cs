using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public bool levelComplete;

    private UI ui;
    private int level;

    public static Grid instance = null;

    #region grid_variables
    public GameObject emptySpace;
    [Header("Cable sprite types")]
    public Sprite straight;
    public Sprite t;
    public Sprite cross;
    public Sprite corner;
    [Header("Special Tiles")]
    public Sprite generator;
    public Sprite target;
    public Sprite bomb;

    //Makes it easier to find which sprite to use for each cable
    private Dictionary<CableType, Sprite> cableSpriteDict;

    private Cable[,] grid;
    private GameObject[,] objGrid;

    private int numOfTargets;
    private int targetsLit;

    #endregion

    private void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
    }

    private void Start() {
        ui = GameObject.Find("Canvas").GetComponent<UI>();

        cableSpriteDict = new Dictionary<CableType, Sprite> {
            {CableType.STRAIGHT, straight},
            {CableType.T, t },
            {CableType.CROSS, cross },
            {CableType.CORNER, corner },
            {CableType.GENERATOR, generator },
            {CableType.TARGET, target },
            {CableType.BOMB, bomb }
        };

        level = 1;
        ui.SetLevel(level);

        grid = LevelInformation.GetLevel(level);
        CreateGrid();

        UpdateConnections();
    }

    #region level_functions

    public void PlayLevelOne() {
        level = 1;
        ui.SetLevel(level);
        levelComplete = false;

        grid = LevelInformation.GetLevel(level);

        for (int i = 0; i < objGrid.GetLength(0); i++) { 
            for (int j = 0; j < objGrid.GetLength(1); j++) {
                Destroy(objGrid[i, j]);
            }
        }

        CreateGrid();
    }

    public void RestartLevel() {
        levelComplete = false;
        ui.SetLevel(level);

        grid = LevelInformation.GetLevel(level);

        for (int i = 0; i < objGrid.GetLength(0); i++)
            for (int j = 0; j < objGrid.GetLength(1); j++) {
                Destroy(objGrid[i, j]);
            }

        CreateGrid();
    }

    public void NextLevel() {
        levelComplete = false;

        level++;
        ui.SetLevel(level);

        grid = LevelInformation.GetLevel(level);

        for (int i = 0; i < objGrid.GetLength(0); i++)
            for (int j = 0; j < objGrid.GetLength(1); j++) {
                Destroy(objGrid[i, j]);
            }

        CreateGrid();

    }

    private void FinishLevel() {
        levelComplete = true;

        if (LevelInformation.GetLevel(level + 1) == null) {
            ui.WinGame();
            return;
        }

        ui.CompleteLevel();
    }

    #endregion

    #region update_connections_functions
    //Turns all tiles connected to the generator yellow
    public void UpdateConnections() {
        //Reset each grid's color
        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; j < grid.GetLength(1); j++) {
                objGrid[i, j].GetComponent<SpriteRenderer>().color = Color.white;
            }
        }

        targetsLit = 0;

        //Change connected tiles to yellow
        for (int i = 0; i < grid.GetLength(0); i++) {
            for (int j = 0; j < grid.GetLength(1); j++) {
                if (grid[i, j].cableType == CableType.GENERATOR) {
                    UpdateConnections(i, j);
                    return;
                }
            }
        }
    }

    private void UpdateConnections(int i, int j) {
        objGrid[i, j].GetComponent<SpriteRenderer>().color = Color.yellow;

        if (grid[i, j].cableType == CableType.BOMB) {
            Debug.Log("hit bomb");
        }

        if (grid[i, j].cableType == CableType.TARGET) {
            targetsLit++;
        }

        if (targetsLit >= numOfTargets) {
            FinishLevel();
            return;
        }

        foreach (int connection in grid[i, j].GetConnections()) {
            //Find the next grid location to check
            int iNext = -1;
            int jNext = -1;
            if (connection == 0) {
                iNext = i - 1;
                jNext = j;
            } else if (connection == 1) {
                iNext = i;
                jNext = j + 1;
            } else if (connection == 2) {
                iNext = i + 1;
                jNext = j;
            } else if (connection == 3) {
                iNext = i;
                jNext = j - 1;
            }

            //If position is out of bounds, or if the square is already lit
            if (iNext >= objGrid.GetLength(0) || jNext >= objGrid.GetLength(1) || iNext < 0 || jNext < 0 ||
                objGrid[iNext, jNext].GetComponent<SpriteRenderer>().color == Color.yellow)
                continue;

            //If square doesn't have a connection to current square
            //0 - 2
            //1 - 3
            if (connection == 0 && grid[iNext, jNext].HasConnection(2)) {
                UpdateConnections(iNext, jNext);
            } else if (connection == 2 && grid[iNext, jNext].HasConnection(0)) {
                UpdateConnections(iNext, jNext);
            } else if (connection == 1 && grid[iNext, jNext].HasConnection(3)) {
                UpdateConnections(iNext, jNext);
            } else if (connection == 3 && grid[iNext, jNext].HasConnection(1)) {
                UpdateConnections(iNext, jNext);
            }
        }
    }
    #endregion

    #region grid_functions
    private void CreateGrid() {
        float offset = 9f;
        float startPos = 4.5f;
        int gridSize = grid.GetLength(0);

        objGrid = new GameObject[gridSize, gridSize];
        numOfTargets = 0;

        float yPos = startPos - (offset / gridSize / 2);

        //Row
        for (int i = 0; i < gridSize; i++) {
            float xPos = -startPos + (offset / gridSize / 2);

            //Col
            for (int j = 0; j < gridSize; j++) {
                GameObject space = CreateSpace(grid[i, j], i * gridSize + j, xPos, yPos);
                objGrid[i, j] = space;

                if (grid[i, j].cableType == CableType.TARGET)
                    numOfTargets++;

                xPos += offset / gridSize;
            }

            yPos -= offset / gridSize;
        }
    }

    private GameObject CreateSpace(Cable c, int spaceNum, float xPos, float yPos) {
        float gridSizeMod = 60f;

        GameObject space = Instantiate(emptySpace, gameObject.transform);

        space.transform.localScale = new Vector2(gridSizeMod / grid.GetLength(0), gridSizeMod / grid.GetLength(0));
        space.transform.localPosition = new Vector2(xPos, yPos);
        space.name = spaceNum.ToString();

        space.GetComponent<GridSpace>().cable = c;
        SetSprite(space, c);
        
        return space;
    }

    private void SetSprite(GameObject space, Cable c) {
        if (c.cableType == CableType.EMPTY)
            return;

        space.GetComponent<SpriteRenderer>().sprite = cableSpriteDict[c.cableType];
        space.transform.eulerAngles = new Vector3(0, 0, -c.GetRotation());
    }

    #endregion
}
