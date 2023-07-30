using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float playerHealth = 100;
    public float playerMaxHealth = 100;
    public float playerMinHealth = 1;
    public float playerAttackStrength = 1;
    public float playerSpeed = 8;
    public float jumpPower = 10;
    private bool isFacingRight = true;

    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        float horizontalInput = Input.GetAxis("Horizontal");

        if (playerHealth < playerMinHealth)
        {
            Destroy(gameObject);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }

        rb.velocity = new Vector2(horizontalInput * playerSpeed, rb.velocity.y);

        Flip();

    }

    private void Flip()
    {
        if (isFacingRight && rb.velocity.x < 0f || !isFacingRight && rb.velocity.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}
