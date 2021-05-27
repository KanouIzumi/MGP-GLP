using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public Transform feet;
    public float feetRadius;
    public LayerMask layerMask;


    private Animator animator;
    private Rigidbody2D rb;
    private bool isFacingRight;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        isFacingRight = true;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {
        //This is for computer
        //Input
        //float inputH = Input.GetAxisRaw("Horizontal");
        float inputH = JoyStickManager.instance.GetDirection().x;
        float inputV = JoyStickManager.instance.GetDirection().y;

        //Play animator
        animator.SetFloat("hVelocity", Mathf.Abs(inputH));

        //Apply velocity
        rb.velocity = new Vector2(inputH * speed, rb.velocity.y);

        //check facing direction
        if (inputH > 0 && isFacingRight == false)
        {
            Flip();
            isFacingRight = true;
        }

        else if (inputH < 0 && isFacingRight == true)
        {
            Flip();
            isFacingRight = false;
        }

        //check for ground
        if (Physics2D.OverlapCircle(feet.position, feetRadius, layerMask) && isGrounded == false)
        {
            isGrounded = true;
        }

        //Keyboard//
        //Jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        //JoyStick
        if(inputV > 0.75f)
        {
            Jump();
        }


        //////This is for Phone version
        //if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;

        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        //float inputH = Input.GetAxisRaw("Horizontal");
        //        //float inputH = JoyStickManager.instance.GetDirection().x;
        //        //float inputV = JoyStickManager.instance.GetDirection().y;

        //        //Play animator
        //        animator.SetFloat("hVelocity", Mathf.Abs(inputH));

        //        //Apply velocity
        //        rb.velocity = new Vector2(inputH * speed, rb.velocity.y);

        //        //check facing direction
        //        if (inputH > 0 && isFacingRight == false)
        //        {
        //            Flip();
        //            isFacingRight = true;
        //        }

        //        else if (inputH < 0 && isFacingRight == true)
        //        {
        //            Flip();
        //            isFacingRight = false;
        //        }

        //        //check for ground
        //        if (Physics2D.OverlapCircle(feet.position, feetRadius, layerMask) && isGrounded == false)
        //        {
        //            isGrounded = true;
        //        }

        //        //JoyStick
        //        if (inputV > 0.75f)
        //        {
        //            Jump();
        //        }
        //    }

        //}
        
    }

    private void Flip()
    {
        float scaleX = transform.localScale.x;
        scaleX *= -1;
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
    }

    public void Jump()
    {
        if(isGrounded == true)
        {
            //rb.velocity += Vector2.up * jumpForce;
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }


}
