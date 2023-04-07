using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapController : Singleton<MapController>
{
    [Header("Params:")]
    [Space]
    [Header("Cell size")]
    [SerializeField] private float cellSize = 1f;
    [Space]
    [Header("Map size")]
    [SerializeField] private int mapSizeX;
    [SerializeField] private int mapSizeY;
    [Space]
    [Header("Objects WHAT we move")]
    [SerializeField] private List<GameObject> objectsInMinigame;
    [Space]
    [Header("Objects WHERE we move")]
    [SerializeField] private List<GameObject> objectsPlace;
    [Space]
    [Header("Needed points")]
    [SerializeField] private int points = 10;

    private Grid grid;

    protected override void Awake()
    {
        base.Awake();

        if (mapSizeX % 2 != 0 || mapSizeY % 2 != 0)
        {
            Debug.LogWarning("Set map size to %2=0 value");
        }

        grid = new Grid(mapSizeX, mapSizeY);

    }

    private void Update()
    {
        if (points == 0)
        {
            EndGame();
        }
    }

    public (int, int) toArrayIdConverter(Vector2 value)
    {
        (int, int) newValue;

        value.x = Mathf.Round(value.x / cellSize);
        value.y = Mathf.Round(value.y / cellSize);

        value.x += mapSizeX / 2;
        value.y += mapSizeY / 2;

        newValue = ((int)value.x, (int)value.y);

        return newValue;
    }

    public (int, int) GetMapSize()
    {
        return (mapSizeX, mapSizeY);
    }

    public void MoveObject(ObjectsInPuzzle obj, Vector2 oldPositionVector, (int, int) moveDirection)
    {
        var oldPosition = toArrayIdConverter(oldPositionVector);

        var x = oldPosition.Item1;
        var y = oldPosition.Item2;
        var newX = oldPosition.Item1 + moveDirection.Item1;
        var newY = oldPosition.Item2 + moveDirection.Item2;

        grid.moveObject(x, y, newX, newY);

    }

    public int ObstacleChecker(Vector2 position)
    {
        var pos = toArrayIdConverter(position);
        return grid.checkValue(pos.Item1, pos.Item2);
    }

    public int ObstacleChecker(int x, int y)
    {
        return grid.checkValueForPlayer(x, y);
    }

    public void InitializePlayer(Vector2 playerPosition)
    {
        var position = toArrayIdConverter(playerPosition);
        grid.SetPlayer(position);
        Debug.Log(position);
        Debug.Log(playerPosition);
    }

    public void MovePlayer(Vector2 position)
    {
        grid.movePlayer(((int)position.x, (int)position.y));
    }

    public float GetCellSize()
    {
        return (cellSize);
    }

    public void ObjectWasPlaced(Transform tr)
    {
        tr.gameObject.SetActive(false);
        points -= 1;
        Debug.Log("POINT");
    }

    private void EndGame()
    {
        SceneManager.LoadScene("GameScene");
    }

}
