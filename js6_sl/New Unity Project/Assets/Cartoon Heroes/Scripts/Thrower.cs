using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrower : MonoBehaviour
{
    private float timebtwshots;
    public float starttimebtwshots;

    public GameObject projectile;
    public Transform Player;

    // start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(timebtwshots <= 0)

        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timebtwshots = starttimebtwshots;
        }

        else
        {
            timebtwshots -= Time.deltaTime;
        }
    }
}
