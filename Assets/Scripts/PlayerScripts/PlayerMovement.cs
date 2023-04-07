using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movespeed = 3f;

    /// <summary>
    /// Script in scene to add footsteps sound
    /// </summary>
    [SerializeField] private SoundClips soundClips;

    private Rigidbody2D rb;
    private Animator animator;

    private Vector2 movement;

    private bool CanMove;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (!CanMove)
        {
            return;
        }

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // Remembering the last direction for the id sprite of the character
        if (movement.x != 0 || movement.y != 0)
        {
            soundClips.RunningSound(0); // play running sound

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

    public (float, float) GetPosition()
    {
        var pos = gameObject.transform.position;
        return (pos.x, pos.y);
    }
}
