using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movespeed = 3f;

    private Rigidbody2D rb;

    [SerializeField] private Animator animator;

    private Vector2 movement;

    private bool CanMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Remembering the last direction for the id sprite of the character
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("IdleHorizontal", movement.x);
            animator.SetFloat("IdleVertical", movement.y);
        }
    }

    private void FixedUpdate()
    {
        if (!CanMove)
        {
            return;
        }

        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
    }

    public void CanMoveChanging(bool state)
    {
        CanMove = state;
    }
}
