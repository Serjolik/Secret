using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    [Header("Player start stats")]
    [SerializeField] private string playerName = "Test name";
    [SerializeField] private float health = 100f;

    [Header("End game event")]
    public GameEvent endGameEvent;

    [Header("Inventory window")]
    [SerializeField] private UIInventory InventoryUI;
    [SerializeField] private UIItemInfo ItemUI;

    private bool playerActive;
    private PlayerClass player;
    private PlayerInventory playerInventory;


    private void Start()
    {
        playerActive = true;
        player = new PlayerClass(playerName, health);
        playerInventory = new PlayerInventory(InventoryUI, ItemUI);
    }

    private void Update()
    {
        if (!playerActive)
        {
            return;
        }
    }

    public void DamageDealt(float damage)
    {
        player.DamageDealt(damage);
        if (player.health <= 0)
        {
            EndGame();
        }
    }

    public void AddItem(Item item)
    {
        playerInventory.AddItem(item);
    }

    private void EndGame()
    {
        playerActive = false;
        endGameEvent.TriggerEvent();
    }

    public (string, string) GetItems()
    {
        var items = playerInventory.GetItems();
        string itemsNames = "";
        string itemsNumbers = "";

        foreach (var item in items)
        {
            itemsNames += item.itemName + ", ";
            itemsNumbers += item.totalItems + ", ";
        }

        if (itemsNames != "")
        {
            return(
                itemsNames.Substring(0, itemsNames.Length - 2),
                itemsNumbers.Substring(0, itemsNumbers.Length - 2)
                );
        }

        return (itemsNames, itemsNumbers);
    }
}
