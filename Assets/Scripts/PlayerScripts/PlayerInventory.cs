using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private List<Item> inventory;
    private UIInventory UI;

    public PlayerInventory(UIInventory ui)
    {
        inventory = new List<Item>();
        UI = ui;
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        UI.UpdateImages(itemSprites());

    }

    public void AddItem(string name, int number, Sprite sprite)
    {   // if we don't have an instance of the item
        foreach (var item in inventory)
        {
            if (item.itemName == name)
            {
                item.TotalItemsChange(number);
                return;
            }
        }
        inventory.Add(new Item(name, number, sprite));
    }

    public void RemoveItem(string name)
    {
        foreach (var item in inventory)
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
                    inventory.Remove(item);
                    break;
                }
            }
        }
    }

    public bool SearchItem(string name)
    {
        foreach (var item in inventory)
        {
            if(item.itemName == name)
            {
                return true;
            }
        }
        return false;
    }

    private List<Sprite> itemSprites()
    {
        var list = new List<Sprite>();
        foreach (Item item in inventory)
        {
            list.Add(item.sprite);
        }

        return list;
    }

}
