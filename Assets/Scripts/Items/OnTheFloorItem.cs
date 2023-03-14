using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// the script is responsible for the added item to player
/// </summary>
public class OnTheFloorItem : MonoBehaviour, IPickupable
{
    /// <summary>
    /// the name of an object is responsible for its properties
    /// </summary>
    [SerializeField] private string itemName = "name";
    /// <summary>
    /// Text about this item
    /// </summary>
    [SerializeField] private string itemText;
    /// <summary>
    /// parameter is responsible for the number of items in the stack
    /// </summary>
    [SerializeField] private int numbersOfItems = 1;

    private Sprite sprite;
    private Player player;

    private Item thisItem;

    private bool inPlayerRange;

    private void Awake()
    {
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        sprite = GetComponent<SpriteRenderer>().sprite;
        thisItem = new Item(itemName, itemText, numbersOfItems, sprite);
        
    }

    public void Pickup()
    {
        player.AddItem(thisItem);
    }

    private void Update()
    {
        if (inPlayerRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
                Destroy(gameObject);
            }
        }
    }


    // Triggering zone

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }

        player = collision.GetComponentInParent<Player>();
        inPlayerRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag != "Player")
        {
            return;
        }

        inPlayerRange = false;
    }

}
