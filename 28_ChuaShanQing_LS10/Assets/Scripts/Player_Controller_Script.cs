using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Controller_Script : MonoBehaviour
{

    public Rigidbody2D rb;

    public float moveSpeed;
    public float jumpPower;

    public Transform groundcheck;
    public float groundcheckradius;
    public LayerMask ground;
    private bool onGround;

    public GameObject coinCountText;
    public int coinCount;

    private AudioSource audioSource;
    public AudioClip[] AudioClipBGMArr;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = this.GetComponent<Rigidbody2D>();
    }


    private void FixedUpdate()
    {
        onGround = Physics2D.OverlapCircle(groundcheck.position, groundcheckradius, ground);
    }



    // Update is called once per frame
    void Update()
    {
        //this is for PC
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.localScale = new Vector3(-1, 1, 1);
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.localScale = new Vector3(1, 1, 1);
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space) && onGround)
        {
            audioSource.PlayOneShot(AudioClipBGMArr[1]);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }


        if( Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }

        if(transform.position.y < -6)
        {
            SceneManager.LoadScene("LoseScene");
        }

        //// for mobile devices
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
               
        //    }
        //}

    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Goal") && coinCount == 5 )
        {
            SceneManager.LoadScene("WinScene");
        }

        if (collision.gameObject.CompareTag("Crystal"))
        {
            coinCount++;
            audioSource.PlayOneShot(AudioClipBGMArr[0]);
            coinCountText.GetComponent<Text>().text = "Coin: " + coinCount;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            audioSource.PlayOneShot(AudioClipBGMArr[2]);
            SceneManager.LoadScene("LoseScene");
        }

    }

    public void Left()
    {
        transform.localScale = new Vector3(1, 1, 1);
        rb.velocity = new Vector2(-moveSpeed, rb.velocity.y);
    }

    public void Right()
    {
        transform.localScale = new Vector3(-1, 1, 1);
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
        if (onGround == true)
        {
            audioSource.PlayOneShot(AudioClipBGMArr[1]);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }
    }
}
