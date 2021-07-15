using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning_Scripts : MonoBehaviour
{

    public Transform[] SpawnPoints;
    public GameObject[] Balloons;
     
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(6);

        for (int i = 0; i < 3; i++)
        {
            Instantiate(Balloons[i], SpawnPoints[i].position, Quaternion.identity);
        }

        StartCoroutine(StartSpawning());

    }

}
