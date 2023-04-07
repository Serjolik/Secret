using System.Collections;
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

        mapController.InitializePlayer(new Vector2(transform.position.x, transform.position.y));
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        if (!canMove)
        {
            return;
        }

        if (movement.x == 0 && movement.y == 0)
        {
            return;
        }

        if (movement.x != 0 && movement.y != 0)
        {
            return;
        }

        TryToMove();
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

    private void TryToMove()
    {
        int objectID = mapController.ObstacleChecker((int)movement.x, (int)movement.y);
        int nextObjectID;

        if (objectID == 10)
        {
            return;
        }

        if (objectID == 1)
        {
            nextObjectID = mapController.ObstacleChecker((int)movement.x * 2, (int)movement.y * 2);

            if (nextObjectID == 1 || nextObjectID == 10)
                return;
        }

        Move();
    }

    private void Move()
    {
        mapController.MovePlayer(movement);
        gameObject.transform.position += new Vector3(movement.x * moveRange, movement.y * moveRange);
    }

}
