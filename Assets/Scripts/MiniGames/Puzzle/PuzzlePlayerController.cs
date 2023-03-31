using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlePlayerController : MonoBehaviour
{
    [Header("Time to next move")]
    [SerializeField] [Range(0.1f, 2)]
    private float moveDelay = 0.3f;

    private MapController mapController;

    private Vector2 movement;
    private bool canMove;

    private float moveRange;

    private (int, int) mapSize;

    private void Start()
    {
        canMove = true;

        mapController = GetComponentInParent<MapController>();
        if (mapController == null)
        {
            Debug.LogWarning("CANT REACH MAP CONTROLLER");
            return;
        }
        mapSize = mapController.GetMapSize();
        moveRange = mapController.GetCellSize();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (movement.x == 0 && movement.y == 0)
        {
            return;
        }

        if (!canMove)
        {
            return;
        }

        Move();
        StartCoroutine(movingDelay());
    }

    public Vector2 getDirection()
    {
        return movement;
    }

    private IEnumerator movingDelay()
    {
        canMove = false;
        yield return new WaitForSeconds(moveDelay);
        canMove = true;
    }

    private void Move()
    {
        gameObject.transform.position += new Vector3(movement.x * moveRange, movement.y * moveRange);
    }

}
