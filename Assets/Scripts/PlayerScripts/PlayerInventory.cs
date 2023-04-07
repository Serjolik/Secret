using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory
{
    private List<Item> inventory;
    private UIInventory UIPic;
    private UIItemInfo UIInfo;

    public PlayerInventory(UIInventory uiPic, UIItemInfo uiInfo)
    {
        inventory = new List<Item>();
        UIPic = uiPic;
        UIInfo = uiInfo;
    }

    public void AddItem(Item item)
    {
        inventory.Add(item);
        UIPic.UpdateImages(itemSprites());
        UIInfo.UpdateMassives(itemNames(), itemTexts());
    }

    public void AddItem(string name, string text, int number, Sprite sprite)
    {   // if we don't have an instance of the item
        foreach (var item in inventory)
        {
            if (item.itemName == name)
            {
                item.TotalItemsChange(number);
                return;
            }
        }
        inventory.Add(new Item(name, text, number, sprite));
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

    private List<string> itemNames()
    {
        var list = new List<string>();
        foreach (Item item in inventory)
        {
            list.Add(item.itemName);
        }

        return list;
    }

    private List<string> itemTexts()
    {
        var list = new List<string>();
        foreach (Item item in inventory)
        {
            list.Add(item.itemText);
        }

        return list;
    }

    public List<Item> GetItems()
    {
        return inventory;
    }

}
