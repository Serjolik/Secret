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

    public (int, int) GetMapSize()
    {
        return (mapSizeX, mapSizeY);
    }

    public float GetCellSize()
    {
        return (cellSize);
    }

}
