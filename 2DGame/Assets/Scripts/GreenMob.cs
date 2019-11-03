using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMob : MonoBehaviour
{
    // Start is called before the first frame update

    public float speedMob;
    public float jumpHeight;
    public Transform chitCheck;
    public float ChitRadious;
    public LayerMask Hit;
    private bool hited;
    private PolygonCollider2D Pc;
    private bool stopHit;
     
    void Start()
    {
        Pc = GetComponent<PolygonCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hited&&!stopHit)
        {
            Destroy(Pc);
            // Pc.enabled = false;
            jump();
            stopHit = true;
          
        }
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-speedMob, GetComponent<Rigidbody2D>().velocity.y);
        hited = Physics2D.OverlapCircle(chitCheck.position, ChitRadious, Hit);
      //  colision = Physics2D.OverlapCircle(checkColision.position, checkColisionRadius, Colider);
        //colision = Physics2D.OverlapCircle(checkColsionRight.position, checkColisionRadiusright, Colider);
    }

    public void jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, jumpHeight);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ground")
        {
            Debug.Log("Colision detected");
            speedMob = speedMob * (-1);
        }
    }
}
