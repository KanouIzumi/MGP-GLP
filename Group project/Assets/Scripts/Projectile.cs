using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y, player.position.z);

        Destroy(gameObject,3);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if(transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerScript>().MinusHP(2);
            Destroy(gameObject);
        }

<<<<<<< HEAD
        if(other.CompareTag("Wall"))
=======

        if (other.CompareTag("Wall"))
>>>>>>> 6401c1452468975be2f8f27304942181d8030300
        {
            Destroy(gameObject);
        }

    }
}
