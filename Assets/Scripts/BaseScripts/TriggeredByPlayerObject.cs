using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class TriggeredByPlayerObject : MonoBehaviour
{
    private PlayStateManager stateManager;

    private bool inRange;

    protected virtual void Awake()
    {
        stateManager = GameObject.FindGameObjectWithTag("PlayStateManager").GetComponent<PlayStateManager>();

        var boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            inRange = false;
        }
    }

    private void Update()
    {
        if (!inRange)
            return;

        if (!Input.GetKeyDown(KeyCode.E))
            return;

        if (!stateManager.isFree())
            return;

        Trigger();
    }

    protected virtual void Trigger()
    {
        Debug.Log("Do some logic");
        return;
    }
}
