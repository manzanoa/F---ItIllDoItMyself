using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Myself : MonoBehaviour
{
    private float moveH;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;

    bool jump = false;
    bool isGrounded = false;

    //TODO
    //-movement (copy and paste or inheritance)
    //-set specific keys for Myself
    //Myself jump

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            moveH = -1;
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            moveH = 1;
        }
        else if (Input.GetKeyDown(KeyCode.I) && isGrounded)
        {
            jump = true;
        }
        else if(!Input.anyKey)
        {
            moveH = 0;
        }
        
    }

    private void FixedUpdate()
    {
        //left or right movement
        rb.velocity = new Vector2(moveH * speed, rb.velocity.y);

        //jumps
        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jump = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Floor"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
