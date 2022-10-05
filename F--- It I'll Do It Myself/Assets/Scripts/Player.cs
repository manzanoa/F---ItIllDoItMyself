using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    float moveH;
    bool facingRight = true;
    bool jump;
    int jumpCounter;
    int jumpCounterMax = 2;
    bool isGrounded = true;


    [SerializeField] float speed;
    [SerializeField] float jumpHeight;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] Rigidbody2D me, myself;

    // Start is called before the first frame update
    void Start()
    {
        jumpCounter = jumpCounterMax;
    }

    // Update is called once per frame
    void Update()
    {
        //takes the horizontal input
        moveH = Input.GetAxis("Horizontal");

        //determines if player is facing the right or not
        if (moveH > 0)
        {
            facingRight = true;
        }
        else if (moveH < 0)
        {
            facingRight = false;

        }

        //jumping
        if (Input.GetButtonDown("Jump") && (IsGrounded() || jumpCounter > 0))
        {
            jump = true;
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            //Split
            //-Instantiate Me and Myself
            //-Destroy I (Player) <-- do not do
            //Instantiate(me, new Vector2(rb.transform.position.x - 1, rb.transform.position.y), rb.transform.rotation);
            //Instantiate(myself, new Vector2(rb.transform.position.x + 1, rb.transform.position.y), rb.transform.rotation);
            //Destroy(this.gameObject);

            me.transform.position = new Vector2(rb.transform.position.x - 1, rb.transform.position.y);
            myself.transform.position = new Vector2(rb.transform.position.x + 1, rb.transform.position.y);

            me.gameObject.SetActive(true);
            myself.gameObject.SetActive(true);
            this.gameObject.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        //for flipping the sprite around
        if (facingRight)
        {
            this.transform.eulerAngles = new Vector2(0, 0);
        }
        else
        {
            this.transform.eulerAngles = new Vector2(0, 180);
        }

        //left or right movement
        rb.velocity = new Vector2(moveH * speed, rb.velocity.y);

        //jumps
        if (jump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpHeight);
            jumpCounter--;
            jump = false;
        }
    }

    private bool IsGrounded()
    {
        return isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag.Equals("Floor"))
        {
            isGrounded = true;
            jumpCounter = jumpCounterMax;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
}
