using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClass
{
    public string name { get; private set; }
    public float health { get; private set; }
    public float speed { get; private set; }

    private List<string> inventory;

    public PlayerClass(string name, float health, float speed)
    {
        this.name = name; this.health = health; this.speed = speed;
        inventory = new List<string>();
    }

    public void DamageDealt(float damage)
    {
        this.health -= damage;
    }

    public int InventoryItemSearch(string itemName)
    {
        // return item index if item exist and -1 if no exists
        if (inventory.Contains(itemName))
        {
            return inventory.IndexOf(itemName);
        }
        else
        {
            return -1;
        }
    }

    public bool InventoryItemDelete(string itemName)
    {
        return inventory.Remove(itemName);
    }

}
