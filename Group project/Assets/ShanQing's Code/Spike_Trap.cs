using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Trap : MonoBehaviour
{
    //how often it will damage
    [Tooltip("Damage speed on contact with trap")]
    public int ContactTrapDamage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerScript>().MinusHP(10);
        }
    }

}
