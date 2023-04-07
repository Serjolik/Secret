using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInPuzzle : MonoBehaviour
{
    private PuzzlePlayerController playerController;
    private MapController mapController;

    private Vector2 position;

    private void Start()
    {
        mapController = GetComponentInParent<MapController>();
        if (mapController == null)
        {
            Debug.LogWarning("CANT REACH MAP CONTROLLER");
            return;
        }

        transform.position = VectorConverting(transform.position, mapController.GetCellSize());

        position = transform.position;
        Move((0, 0));
    }

    public Vector3 VectorConverting(Vector3 vector, float value)
    {
        return new Vector3(
            Mathf.Round(vector.x / value) * value,
            Mathf.Round(vector.y / value) * value,
            vector.z
            );
    }

    private bool canMove(Vector2 moveDirection)
    {
        if (mapController.ObstacleChecker(position + moveDirection) == 10)
        {
            Debug.Log("map border");
            return false;
        }

        if (mapController.ObstacleChecker(position + moveDirection) == 1)
        {
            Debug.Log("another object");
            return false;
        }

        return true;
    }

    public void Move((int, int) value)
    {
        mapController.MoveObject(this, position, value);

        position.x += value.Item1;
        position.y += value.Item2;

        var step = new Vector3(value.Item1 * mapController.GetCellSize(), value.Item2 * mapController.GetCellSize());
        transform.position += step;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController = collision.GetComponent<PuzzlePlayerController>();

            if (playerController == null)
            {
                Debug.LogWarning("Player in null");
                return;
            }

            TryToMove(playerController.getDirection());
        }
    }

    private void TryToMove(Vector2 moveDirection)
    {
        if (canMove(moveDirection))
        {
            Move(((int)moveDirection.x, (int)moveDirection.y));
        }
    }

}
