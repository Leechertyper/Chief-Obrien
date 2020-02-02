using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    [Header("Object References")]
    public Rigidbody2D rb;

    Vector2 movementDirection;

    private void Start()
    {

    }

    void Update()
    {
        GetInput();
    }

    void FixedUpdate()
    {
        DoMovement();
    }

    /**
     * Gets the input from the mouse and keyboard and controller.
     */
    void GetInput()
    {

        void GetMovementInput()
        {
            movementDirection.x = Input.GetAxisRaw("Horizontal");
            movementDirection.y = Input.GetAxisRaw("Vertical");
        }

        GetMovementInput();
    }

    /**
     * Moves the player from user input.
     */
    void DoMovement()
    {
        void MoveCharacter()
        {
            float step = movementSpeed * 3f;
            rb.MovePosition(rb.position + movementDirection * step * Time.fixedDeltaTime);
        }

        MoveCharacter();
    }

}
