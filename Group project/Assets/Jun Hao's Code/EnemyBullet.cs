using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;

    private Transform player;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector3(player.position.x, player.position.y, player.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

        if (transform.position.x == target.x && transform.position.y == target.y && transform.position.z == target.z)
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player got hit");
            other.gameObject.GetComponent<PlayerScript>().MinusHP(10);
            DestroyBullet();
        }
    }


    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
