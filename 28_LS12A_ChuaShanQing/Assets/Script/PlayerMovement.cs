using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            this.transform.Translate(Vector3.forward * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            this.transform.Translate(Vector3.back * Time.deltaTime);
        }
    }
}
