using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int width;
    private int height;

    enum keys
    {
        None = 0,
        Object = 1,
        Target = 2,
        Player = 3,
        Border = 4
    };

    private keys[,] gridArray;
    
    public Grid(int width, int height)
    {
        this.width = width + 2;
        this.height = height + 2;

        gridArray = new keys[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                    gridArray[x, y] = keys.Border;
                else
                    gridArray[x, y] = keys.None;
            }
        }
    }

    public void moveObject(int x, int y, int newX, int newY)
    {
        gridArray[x, y] = keys.None;
        gridArray[x, y] = keys.Object;
    }

    public void movePlayer(int x, int y, int newX, int newY)
    {
        gridArray[x, y] = keys.None;
        gridArray[newX, newY] = keys.Player;
    }

    public int checkValue(int x, int y)
    {
        return (int)gridArray[x, y];
    }

}
