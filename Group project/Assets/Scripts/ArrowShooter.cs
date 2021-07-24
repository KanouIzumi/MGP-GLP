using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    private float timeshots;
    public float starttime;
    public float speed;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeshots <= 0)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            timeshots = starttime;
        }
        else
        {
            timeshots -= Time.deltaTime;
        }
    }
}
