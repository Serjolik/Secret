using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName { get; private set; }
    public int totalItems { get; private set; }
    public Sprite sprite { get; private set; }

    public Item(string name, int number, Sprite sprite)
    {
        itemName = name; totalItems = number; this.sprite = sprite;
    }

    public void TotalItemsChange(int number)
    {
        totalItems += number;
    }

}
