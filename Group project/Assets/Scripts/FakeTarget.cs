using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeTarget : MonoBehaviour
{


    [Tooltip("Health of the target")]
    public int HealthPoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnHit(int damage)
    {
        Destroy(gameObject);
    }
}
