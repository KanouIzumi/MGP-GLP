using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Text timeText;
    public Text scoreText;
    public GameObject Point;


    int score;
    int totalScore;
    public float levelTime;


    private AudioSource audioSource;
    public AudioClip[] AudioClipBGMArr;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        //this is to check how many point gameobject at the start of the game
        totalScore = GameObject.FindGameObjectsWithTag("Collectible").Length;
    }

    // Update is called once per frame
    void Update()
    {
        //this is to make the time minus 
        levelTime -= Time.deltaTime;
        timeText.text = "Time: " + levelTime.ToString("0.00");

        LoseMethod();
        Level2();

        Vector3 position = this.transform.position;
        position.x = Mathf.Clamp(transform.position.x, -7.0f, 7.0f);
        position.y = Mathf.Clamp(transform.position.y, -5.0f, 5.0f);
        this.transform.position = position;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MazeLayoutInnerWalls")
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.tag == "Obstacle")
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.tag == "Collectible")
        {
            audioSource.PlayOneShot(AudioClipBGMArr[0]);
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "Score: " + score.ToString();
        }

        if(collision.gameObject.tag == "Walls")
        {
            audioSource.PlayOneShot(AudioClipBGMArr[1]);
        }

        //this is the going to level two
        if (collision.gameObject.tag == "Level2")
        {
            SceneManager.LoadScene("Maze_Level2");
        }

        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("WinGame");
        }
    }


    private void LoseMethod()
    {
        if (levelTime <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    private void Level2()
    {
        if(score == totalScore)
        {
            SceneManager.LoadScene("Maze_Level2");
        }
    }
}
