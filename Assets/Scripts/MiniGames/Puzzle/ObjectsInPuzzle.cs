using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInPuzzle : MonoBehaviour
{
    [Header("Cell position number")]
    [SerializeField] private Vector2 startPosition = Vector2.zero;

    private PuzzlePlayerController playerController;
    private MapController mapController;

    private Vector2 position;
    private Vector2 moveDirection;

    private (int, int) mapSize;

    private float movingDistance;

    private bool canMove => inBound(position + moveDirection);

    private void Start()
    {
        startPosition *= movingDistance;
        gameObject.transform.position = startPosition;
        position = startPosition;

        mapController = GetComponentInParent<MapController>();
        if (mapController == null)
        {
            Debug.LogWarning("CANT REACH MAP CONTROLLER");
            return;
        }
        mapSize = mapController.GetMapSize();
        movingDistance = mapController.GetCellSize();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController = collision.GetComponent<PuzzlePlayerController>();
            TryToMove(playerController.getDirection());
        }
    }

    private void TryToMove(Vector2 moveDirection)
    {
        this.moveDirection = moveDirection;
        if (canMove)
        {
            Move(moveDirection);
        }
    }

    private void Move(Vector2 moveDirection)
    {
        position += moveDirection;
        gameObject.transform.position += new Vector3(moveDirection.x * movingDistance, moveDirection.y * movingDistance);
    }

    private bool inBound(Vector2 position)
    {
        if (Mathf.Abs(position.x) < mapSize.Item1 && Mathf.Abs(position.y) < mapSize.Item2)
        {
            return true;
        }

        return false;
    }

}
