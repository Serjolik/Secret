using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(SpriteRenderer))]
/// <summary>
/// the script is responsible for the added item to player
/// </summary>
public class OnTheFloorItem : ObjectTrigger, IPickupable
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

    public Sprite sprite { get; private set; }
    private Player player;

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

    public (string, int, Sprite) GetValues()
    {
        (string, int, Sprite) tuple = (itemName, numbersOfItems, sprite);
        return tuple;
    }

    private void Update()
    {
        if (playerCollision)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Pickup();
                Destroy(gameObject);
            }
        }
    }

    protected override void TriggerPlayerAction(Collider2D collision)
    {
        player = collision.GetComponentInParent<Player>();
    }

    public void Pickup()
    {
        player.AddItem(this);
    }

}
