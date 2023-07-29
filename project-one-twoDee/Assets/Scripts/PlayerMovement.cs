using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    private float speed = 8f;
    private float jumpingPower = 10f;
    private bool isFacingRight = true;
    private int jumpCounter = 2;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Sets input characterized as "horizontal" to a variable named horizontal
        horizontal = Input.GetAxisRaw("Horizontal");

        //Makes the player jump
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpCounter--;
        }

        //Checks to see if the player has a second jump or not, if they do it alows it to jump
        if (Input.GetButtonDown("Jump") && !isGrounded() && hasSecondJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            jumpCounter--;
        }

        //Makes the player jump higehr if they hold 'jump' for longer
        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f && hasSecondJump())
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.2f);
        }

        //Checks to see if the player is grounded, if the player 
        if (isGrounded())
        {
            jumpCounter = 2;
        }

        //Calls the flip function to visually flip the character
        Flip();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool hasSecondJump()
    {
        if (jumpCounter != 2)
        {
            return false;
        }

        return true;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
