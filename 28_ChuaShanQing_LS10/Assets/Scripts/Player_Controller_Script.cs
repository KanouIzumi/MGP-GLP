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

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            audioSource.PlayOneShot(AudioClipBGMArr[1]);
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
        }


        if(transform.position.y < -6 || Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("GameScene");
        }
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Goal")&& coinCount == 5 )
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

    }
}
