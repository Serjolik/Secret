using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string itemName { get; private set; }
    public string itemText { get; private set; }
    public int totalItems { get; private set; }
    public Sprite sprite { get; private set; }

    public Item(string name, string text, int number, Sprite sprite)
    {
        itemName = name; itemText = text; totalItems = number; this.sprite = sprite;
    }

    public void TotalItemsChange(int number)
    {
        totalItems += number;
    }

}
