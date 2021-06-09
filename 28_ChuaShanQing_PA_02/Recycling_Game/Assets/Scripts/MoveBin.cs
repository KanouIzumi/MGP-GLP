using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveBin : MonoBehaviour
{
    public static MoveBin instance;

    public int distance = 10;
    public Text itemsUpdate;

    //this is for the time 
    public Text timeText;
    public float levelTime;
    float highscore;


    // Start is called before the first frame update

    public int itemsCollected;

    void Start()
    {
        //this is to set the highscore for the frist time the code is running and to make sur eif the code is running
        highscore = PlayerPrefs.GetFloat("Highscore", 0f);

        if (highscore <= 0)
         PlayerPrefs.SetFloat("Highscore", 10000);
        
    }


  void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
    }


    private void Update()
    {
        //this is to check for the time
        levelTime += Time.deltaTime;
        timeText.text = "Time: " + levelTime.ToString("0.00");

        if (itemsCollected >=5)
        {
            PlayerPrefs.SetFloat("Time", levelTime);
           
 
            if (levelTime < highscore)
            {
                HighScore();
            }

            SceneManager.LoadScene("GameWin");
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Reduce")
        {
            SceneManager.LoadScene("GameLose");
        }

        if (other.gameObject.tag == "Recycle")
        {
            Destroy(other.gameObject);
            itemsCollected++;
            itemsUpdate.text = "Recycled items " + itemsCollected.ToString();

        }
    }


    private void HighScore()
    {
        PlayerPrefs.SetFloat("Time", levelTime);

        PlayerPrefs.SetFloat("Highscore", levelTime);
    }


}
