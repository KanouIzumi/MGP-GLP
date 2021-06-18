using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoyStickScript : MonoBehaviour
{
    public Transform player;





    public float speed = 5.0f;

    private bool touchstart = false;
    private Vector2 pointA;
    private Vector2 pointB;

    public Transform innercircle;
    public Transform Outercircle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


          

        // if block to check mouse/ finger is pressed down on the screen 

        if (Input.GetMouseButtonDown(0))
        {
         
            pointA = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
                                                    Camera.main.transform.position.z));


            //anchor the position of the circles  to pointA 
            innercircle.transform.position = pointA * -1;
            Outercircle.transform.position = pointA * -1;

            // sprite renderer will be enabled only when we touch the screen 
            innercircle.GetComponent<SpriteRenderer>().enabled = true;
            Outercircle.GetComponent<SpriteRenderer>().enabled = true;
        }

        
        if(Input.GetMouseButton(0))
        {
         touchstart = true;
        
          pointB = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
                                                  Input.mousePosition.y, Camera.main.transform.position.z));


        }
        else
        {
            touchstart = false;

        }

        MovePlayer(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        
    }

    private void FixedUpdate()    
    {


        if (touchstart)
        {

            Vector2 offset = pointB - pointA;
            Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
            MovePlayer(direction * -1);

             // to make sure the innercircle within the outercircle
            innercircle.transform.position = new Vector2(pointA.x + direction.x, pointA.y + direction.y) * -1;

       
        }

      else
        {
            // when no touch detected the sprite renderer will be disabled

            innercircle.GetComponent<SpriteRenderer>().enabled = false;
            Outercircle.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    void MovePlayer(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime);

    } 
}
