using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
   
    Rigidbody2D rb;
    public int moveSpeed = 2;
    public LayerMask groundLayer;
    float jumpForce = 500;
    bool isGrounded;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () 
    {
        rb.velocity = new Vector2(transform.localScale.x * moveSpeed, rb.velocity.y);
        isGrounded = Physics2D.Linecast(
            transform.position + transform.up * 1,
            transform.position - transform.up * 0.1f,
            groundLayer
        );

        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            Jump();
        }
	}

    void FixedUpdate()
    {
        rb.velocity = new Vector2(transform.localScale.x * moveSpeed,
            rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            Vector2 temp = gameObject.transform.localScale;
            temp.x *= -1;
            gameObject.transform.localScale = temp;
        }
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce);
        isGrounded = false;
    }
}
