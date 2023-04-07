using UnityEngine;

public class Target : MonoBehaviour
{
    [Range(0, 1)] [SerializeField] private float transparence;

    MapController mapController;
    SpriteRenderer spriteRenderer;


    private void Start()
    {
        mapController = GetComponentInParent<MapController>();
        if (mapController == null)
        {
            Debug.LogWarning("CANT REACH MAP CONTROLLER");
            return;
        }

        transform.position = VectorConverting(transform.position, mapController.GetCellSize());

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        ChangeTransparence(transparence);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var obj = collision.GetComponent<ObjectsInPuzzle>();
        if (obj != null)
        {
            mapController.ObjectWasPlaced(collision.transform);
            ChangeTransparence(1);
            this.enabled = false;
        }
    }

    public Vector3 VectorConverting(Vector3 vector, float value)
    {
        return new Vector3(
            Mathf.Round(vector.x / value) * value,
            Mathf.Round(vector.y / value) * value,
            vector.z
            );
    }

    private void ChangeTransparence(float value)
    {
        spriteRenderer.color = new Color(
            spriteRenderer.color.r, 
            spriteRenderer.color.g, 
            spriteRenderer.color.b,
            value
            );
    }

}
