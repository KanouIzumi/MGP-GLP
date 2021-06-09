using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{

    
    public GameObject SpawnedObjects;
    private float spawntime = 1;
    private float spawndelay = 0.8f;
    private int randomobjects;
    float positionX;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", spawntime, spawndelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObject()
    {
    
        positionX = Random.Range(-9f,9f);
        this.transform.position = new Vector3(positionX, transform.position.y, transform.position.z);
        Instantiate(SpawnedObjects, transform.position, transform.rotation);
    }
}
