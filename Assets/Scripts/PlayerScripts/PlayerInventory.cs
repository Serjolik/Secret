using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private List<Item> items = new List<Item>();

    private void Awake()
    {
        canvas.enabled = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            canvas.enabled = !canvas.enabled;
        }
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
                    return;
                }
                else
                {
                    items.Remove(item);
                    return;
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
