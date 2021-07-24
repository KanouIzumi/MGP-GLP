using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorkey : MonoBehaviour
{
    private int keyCount;

    public AudioClip keyAudioClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GameManager.Instance.doorKey(keyCount , keyAudioClip);
            Destroy(gameObject);
        }
    }
}
