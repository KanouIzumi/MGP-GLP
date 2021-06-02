using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Animator animator;
    public float startDelayTime;
    public float levelTime;

    //Text in the game
    public Text scoreText;
    public Text livesText;
    public Text timeText;

    public int lives;
    public int score;

    private float elapsedTime;
    private float levelTimePassed;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        levelTimePassed = levelTime;
        timeText.text = "Time: " + levelTimePassed.ToString("0.00");

        livesText.text = "Lives: " + lives;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime > startDelayTime)
        {
            animator.SetTrigger("StartAnimation");
            levelTimePassed -= Time.deltaTime;
            timeText.text = "Time: " + levelTimePassed.ToString("0.00");

            if(levelTimePassed > levelTime)
            {
                SceneManager.LoadScene("GameWinScene");
            }
        }

        //Creating User Input com
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //checking the state of the animation 
                if (animator.GetCurrentAnimatorStateInfo(0).IsName("Yellow_Animation"))
                {
                    score++;
                    scoreText.text = "Score: " + score;
                }

                else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Green_Animation") || animator.GetCurrentAnimatorStateInfo(0).IsName("Blue_Animation"))
                {
                    lives -= 1;
                    livesText.text = "Lives: " + lives;
                }
            }
                
           
        }



        ////creating User Input for Phone
        //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        //{
        //    Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        //    RaycastHit hit;
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        //checking the state of the animation 
        //        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Yellow_Animation"))
        //        {
        //            score++;
        //            scoreText.text = "Score: " + score;
        //        }
        //    }

        //    else if (animator.GetCurrentAnimatorStateInfo(0).IsName("Green_Animation") || animator.GetCurrentAnimatorStateInfo(0).IsName("Blue_Animation"))
        //    {
        //        lives -= 1;
        //        livesText.text = "Lives: " + lives;
        //    }
        //}


        //When time reach 0
        if (levelTimePassed <= 0)
        {
            timeText.text = "Time: 0";
            PlayerPrefs.SetInt("score", score);

            int highscore = PlayerPrefs.GetInt("Highscore",0);
            //Check if we got new high score
            if(score > highscore)
            {
                PlayerPrefs.SetInt("Highscore", score);
            }


            SceneManager.LoadScene("GameWinScene");
        }


        if (lives <=0)
        {
            livesText.text = "Lives: 0";
            SceneManager.LoadScene("GameLooseScene");
        }

    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
