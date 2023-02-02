using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Player : MonoBehaviour
{
    public GameEvent endGameEvent;
    private bool playerActive;
    private PlayerClass player;
    private PlayerInventory playerInventory;
    [Header("Player start stats")]
    [SerializeField] private string playerName = "Test name";
    [SerializeField] private float health = 100f;
    [SerializeField] private float speed = 10f;


    private void Start()
    {
        playerActive = true;
        player = new PlayerClass(playerName, health, speed);
        playerInventory = PlayerInventory.getInstance();
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
            endGameEvent.TriggerEvent();
        }
    }

    public void AddItem(IPickupable pickupableObject)
    {
        (string iname, int inumber, Sprite isprite)
            = pickupableObject.GetValues();

        Debug.Log("ADD ITEM");
        Debug.Log($"iname = {iname}");

        playerInventory.AddItem(iname, inumber, isprite);
    }

    private void EndGame()
    {
        playerActive = false;
    }
}
