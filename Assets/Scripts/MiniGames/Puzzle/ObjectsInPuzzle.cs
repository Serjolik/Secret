using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsInPuzzle : MonoBehaviour
{
    private PuzzlePlayerController playerController;
    private MapController mapController;

    private Vector2 position;
    private Vector2 moveDirection;

    private bool canMove =>
        !mapController.ObtacleChecker(position + moveDirection);

    private void Start()
    {
        // ѕолучаем глобальные значени€ карты и клеток
        mapController = GetComponentInParent<MapController>();
        if (mapController == null)
        {
            Debug.LogWarning("CANT REACH MAP CONTROLLER");
            return;
        }

    }

    public void SetPosition(Vector2 position)
    {
        this.position = position;
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
        Debug.Log(position + moveDirection);
        this.moveDirection = moveDirection;
        if (canMove)
        {
            Move(moveDirection);
        }
    }

    private void Move(Vector2 moveDirection)
    {
        mapController.MoveObject(transform, position, moveDirection);

        position += moveDirection;
    }

}
