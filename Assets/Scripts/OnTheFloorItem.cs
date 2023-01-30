using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// the script is responsible for the added item to player
/// </summary>
public class OnTheFloorItem : MonoBehaviour
{
    /// <summary>
    /// If you want set your settings
    /// </summary>
    [SerializeField] private bool manualSetting = false;
    [Header("IF MANUAL SETTING ON")]
    /// <summary>
    /// the name of an object is responsible for its properties
    /// </summary>
    [SerializeField] private string itemName = "name";
    /// <summary>
    /// parameter is responsible for the number of items in the stack
    /// </summary>
    [SerializeField] private int numbersOfItems = 1;

    private Sprite sprite;
    private PlayerInventory playerInventory;
    private bool inCollision = false;

    private void Awake()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        sprite = GetComponent<SpriteRenderer>().sprite;
        if (!manualSetting)
        {
            numbersOfItems = 1;
            itemName = name;
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerInventory = collision.GetComponent<PlayerInventory>();
            inCollision = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inCollision = false;
        }
    }

    private void Update()
    {
        if (inCollision)
        {
            DrawMessage();
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
            }
        }
    }

    private void DrawMessage()
    {
        Debug.Log("IM HERE");
        return;
    }
    private void Pickup()
    {
        playerInventory.AddItem(itemName, numbersOfItems, sprite);
        Destroy(gameObject);
    }

}
