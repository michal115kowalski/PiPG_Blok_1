using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    //public Transform Camera;
    public float groundCheckRadius;
    public LayerMask IsGround;
    private bool grounded;
    private bool doublejump;
    private int getCoins =0;
    PolygonCollider2D PC;


    void Start()
    {
        PC = gameObject.GetComponent<PolygonCollider2D>();          
    }

    // Update is called once per frame
    void Update()
    {

      
        if (grounded&&Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump();
            doublejump = true;
        };

        if (doublejump&&!grounded && Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump();
            doublejump = false;
        };


        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)||Input.GetKeyUp(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, IsGround);
    }

    public void jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            getCoins++;
        }

        if (collision.gameObject.tag == "Mob")
        {
            //  gameObject.SendMessage("GameOwer","GameOwer");
            jump();
            PC.enabled = false;
            
        }
    }

}
