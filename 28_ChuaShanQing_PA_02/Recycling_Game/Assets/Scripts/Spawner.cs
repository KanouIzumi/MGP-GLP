using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject[] SpawnedObjects;
    private float spawntime = 1f;
    private float spawndelay = 0.8f;
    private int randomobjects;
    float positionX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawntime, spawndelay);
    }


    void SpawnObject()
    {
        positionX = Random.Range(-9f,9f);
        this.transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        Instantiate(SpawnedObjects[Random.Range(0, SpawnedObjects.Length)], transform.position, transform.rotation);
    }

}
