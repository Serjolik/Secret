using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.tag == "Player")
            {
                TriggerPlayerAction();
            }
            else
            {
                TriggerOtherAction();
            }
        }
    }

    protected virtual void TriggerPlayerAction()
    {
        Debug.Log($"Trigger in {gameObject} with player");
    }

    protected virtual void TriggerOtherAction()
    {
        Debug.Log($"Trigger in {gameObject} with other object");
    }
}
