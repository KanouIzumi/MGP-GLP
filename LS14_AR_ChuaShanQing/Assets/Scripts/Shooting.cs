using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public Text ScoreText;
    int Score;


   // private AudioSource audioSource;
    //public AudioClip[] AudioClipBGMArr;

    public GameObject arCamera;

    public GameObject smoke;

    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(arCamera.transform.position, arCamera.transform.forward, out hit))
        {
            if (hit.transform.name == "Blue ballon(Clone)" || hit.transform.name == "Purple ballon(Clone)" || hit.transform.name == "Red ballon(Clone)")
            {
                Destroy(hit.transform.gameObject);
                //audioSource.PlayOneShot(AudioClipBGMArr[0]);
                Score++;

                ScoreText.GetComponent<Text>().text = "Score: " + Score.ToString();

                Instantiate(smoke, hit.point, Quaternion.LookRotation(hit.normal));
            }
        }
    }

}
