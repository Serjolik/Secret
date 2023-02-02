using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{
    protected bool playerCollision { get; private set; } = false;
    protected bool objectCollision { get; private set; } = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                playerCollision = true;
                TriggerPlayerAction(collision);
            }
            else
            {
                objectCollision = true;
                TriggerOtherAction(collision);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                playerCollision = false;
            }
            else
            {
                objectCollision = false;
            }
        }
    }

    protected virtual void TriggerPlayerAction(Collider2D collision)
    {
        Debug.Log($"Trigger in {gameObject} with player");
    }

    protected virtual void TriggerOtherAction(Collider2D collision)
    {
        Debug.Log($"Trigger in {gameObject} with other object");
    }
}
