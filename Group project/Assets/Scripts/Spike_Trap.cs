using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Trap : MonoBehaviour
{
    public float rateOfDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Trap touch"); 
            //PlayerScript Instance.'HealthPoint'(rateOfDamage * Time.deltaTime);
        }
    }

}
