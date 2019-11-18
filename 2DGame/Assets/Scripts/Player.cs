using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;

    public float groundCheckRadius;
    public LayerMask IsGround;
    private bool grounded;
    private bool doublejump;
    private int getCoins;
    public Text myPointVariable, myLiveVariable;
    GameObject myTextPointVariable, myTextLiveVariable;
    private int numberlives = 3;


    void Start()
    {

        myTextLiveVariable = GameObject.Find("liveVariable");
        myLiveVariable = myTextLiveVariable.GetComponent<Text>();
        myLiveVariable.text = (numberlives).ToString();

        myTextPointVariable = GameObject.Find("coinVariable");
        myPointVariable = myTextPointVariable.GetComponent<Text>();
        myPointVariable.text = getCoins.ToString();



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
            Vector3 characterScale = transform.localScale;
            characterScale.x = 1;
            transform.localScale = characterScale;
        }


        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            Vector3 characterScale = transform.localScale;
            characterScale.x = -1;
            transform.localScale = characterScale;
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
        SoundManagerScript.PlaySound("jump");


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
        if (collision.gameObject.tag == "Castle")
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.tag == "Mob")
        {
           
            SoundManagerScript.PlaySound("bump");
            if (numberlives > 1)
            {
                --numberlives;
                myLiveVariable.text = numberlives.ToString();
            }
            else
            {
                --numberlives;
                myLiveVariable.text = numberlives.ToString();
                StartCoroutine(Example());
            }

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            SoundManagerScript.PlaySound("bump");

            StartCoroutine(Example());
        }

        if (collision.gameObject.tag == "Coin")
        {
            SoundManagerScript.PlaySound("coin");
            getCoins++;
            myPointVariable.text = getCoins.ToString();
            Destroy(collision.gameObject);
            
        }
    }




    IEnumerator Example()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("GameOver");

    }

}
