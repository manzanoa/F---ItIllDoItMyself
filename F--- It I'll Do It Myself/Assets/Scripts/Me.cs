using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Me : MonoBehaviour
{
    private float moveH;
    bool jump = false;
    bool isGrounded = false;
    bool inRange = false;
    bool faceRight = false;



    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    [SerializeField] float jumpHeight;
    [SerializeField] Rigidbody2D myself, player;

    //TODO
    //-movement (copy and paste or inheritance)
    //-set specific keys for me
    //-when near Myself and with nothing blocking the way remerge into I (player)
    //  -Initialize I and Destroy Me and Myself
    //-Me sheild



    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveH = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            jump = true;
        }
        if(Input.GetKeyDown(KeyCode.Space) && inRange)
        {
            //vector math to find the midpoint of the distance between the 2
            //instantiate at  that location with standard rotation
            //dstroy myself and me <-- do not do

            Vector2 sum = rb.transform.position + myself.transform.position;
            sum = sum / 2;
            player.transform.position = sum;

            if (rb.transform.position.x >= myself.transform.position.x)
            {
                faceRight = true;
                player.transform.eulerAngles = new Vector2(0, -180);
            }
            else
            {
                player.transform.eulerAngles = new Vector2(0, 0);
            }



            player.gameObject.SetActive(true);
            myself.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
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

    public void onRange()
    {
        inRange = true;
    }

    public void outOfRange()
    {
        inRange = false;
    }
}
