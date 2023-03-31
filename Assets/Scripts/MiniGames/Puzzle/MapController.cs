using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        foreach(GameObject obj in objectsInMinigame)
        {
            var position = new Vector2();

            // Ставим корректное положение объектов в сетке
            position.x = Mathf.Round(obj.transform.position.x / cellSize);
            position.y = Mathf.Round(obj.transform.position.y / cellSize);

            obj.transform.position = position * cellSize;

            // Конвертируем значения в элементы матрицы
            position.x += mapSizeX / 2;
            position.y += mapSizeY / 2;

            var objScript = obj.GetComponent<ObjectsInPuzzle>();
            objScript.SetPosition(position);
        }

    }

    public (int, int) GetMapSize()
    {
        return (mapSizeX, mapSizeY);
    }

    public void MoveObject(Transform objTransform, Vector2 oldPosition, Vector2 moveDirection)
    {
        var x = (int)oldPosition.x;
        var y = (int)oldPosition.y;
        var newX = (int)(oldPosition.x + moveDirection.x);
        var newY = (int)(oldPosition.y + moveDirection.y);

        grid.moveObject(x, y, newX, newY);

        objTransform.position += new Vector3(moveDirection.x * cellSize, moveDirection.y * cellSize);

        Debug.Log("POSITIONS");
        Debug.Log(oldPosition);
        Debug.Log(oldPosition + moveDirection);
    }

    public bool ObtacleChecker(Vector2 position)
    {
        if (grid.checkValue((int)position.x, (int)position.y) != 0)
        {
            return true;
        }
        return false;
    }

    public float GetCellSize()
    {
        return (cellSize);
    }

}
