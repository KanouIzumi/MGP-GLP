using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveSphere : MonoBehaviour
{

    bool moveLeft = true;
    float moveDistance = 0;

    public GameObject SphereObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(moveLeft)
        {
            if(moveDistance > -2)
            {
                moveDistance -= Time.deltaTime;
                Vector3 currentposition = transform.position;
                currentposition.x -= Time.deltaTime;
                transform.position = currentposition;
            }

            else
            {
                moveLeft = false;

                SpawnPhere();
            }
        }

        else
        {
            if (moveDistance < 2)
            {
                moveDistance += Time.deltaTime;
                Vector3 currentposition = transform.position;
                currentposition.x += Time.deltaTime;
                transform.position = currentposition;
            }

            else
            {
                moveLeft = true;
            }    
        }
    }

    void SpawnPhere()
    {
        GameObject TempObject = Instantiate(SphereObject, this.transform.position, this.transform.rotation) as GameObject;

        Destroy(TempObject, 3);
    }
}
