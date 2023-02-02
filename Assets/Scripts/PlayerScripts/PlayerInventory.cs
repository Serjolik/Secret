using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInventory : ScriptableObject
{
    private List<Item> items = new List<Item>();

    private static PlayerInventory instance;
    public static PlayerInventory getInstance()
    {
        if (instance == null)
            instance = CreateInstance<PlayerInventory>();
        return instance;
    }


    public void AddItem(string name, int number, Sprite sprite)
    {
        foreach (var item in items)
        {
            if (item.itemName == name)
            {
                item.TotalItemsChange(number);
                return;
            }
        }
        items.Add(new Item(name, number, sprite));
    }

    public void RemoveItem(string name)
    {
        foreach (var item in items)
        {
            if (item.itemName == name)
            {
                if (item.totalItems > 1)
                {
                    item.TotalItemsChange(-1);
                    break;
                }
                else
                {
                    items.Remove(item);
                    break;
                }
            }
        }
    }

    public bool SearchItem(string name)
    {
        foreach (var item in items)
        {
            if(item.itemName == name)
            {
                return true;
            }
        }
        return false;
    }

}
