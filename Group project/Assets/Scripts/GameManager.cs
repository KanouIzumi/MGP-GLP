using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour {
    public static GameManager Instance;

    [Header("Game variables")]
    [Tooltip("Time in seconds")]
    public float RoundTime;

    [Header("Game audioClips")]
    public AudioClip BackgroundMusic;
    public AudioClip GameWinSound;
    public AudioClip GameLoseSound;

    [Header("Text boxes references")]
    public Text ScoreTextbox;
    public string ScoreTextPrefix;

    public Text AmmoTextbox;
    public string AmmoTextPrefix;

    public Text HealthTextbox;
    public string HealthTextPrefix;

    public Text TimeLeftTextbox;
    public string TimeLeftTextPrefix;

    public Text ItemTextbox;
    public string ItemTextPrefix;

    public GameObject GameWin;
    public GameObject GameLose;


    public string SceneName;
    [HideInInspector]
    public bool isGameOver;
    public bool isGameLose;
    
    private int score;
    private int item;
    private int key;
    private int target;
    private AudioSource audioSource;

    // Use this for initialization
    void Awake () {
        if (Instance == null) {
            Instance = this;
        }

        audioSource = GetComponent<AudioSource>();
        audioSource.clip = BackgroundMusic;
        audioSource.Play();

        GameWin.SetActive(false);
        GameLose.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (isGameOver)
            return;

        UpdateTimeLeft();

        if (Input.GetKeyDown(KeyCode.F1))
        {
            SetGameWin(true);
        }

        if (isGameLose)
            return;

    }
    public void itemCount (int itemCount, AudioClip audioClip)
    {
        item += 1;
        Debug.Log("Item get" + item);
        if (item >= 5)
        {
            Destroy(GameObject.FindGameObjectWithTag("Door 1"));
        }
    }
    public void doorKey(int doorKey, AudioClip audioClip)
    {
        key += 1;
        if(key >= 1)
        {
            Destroy(GameObject.FindGameObjectWithTag("Door 2"));
        }
    }
    public void targetCount(int target , AudioClip audioClip)
    {
        target += 1;
        if(key >= 3)
        {
            Destroy(GameObject.FindGameObjectWithTag("Door 1"));
        }
    }

    public void UpdateScore(int _score, AudioClip audioClip) 
    {
        score += _score;
        ScoreTextbox.text = ScoreTextPrefix + score;

        audioSource.PlayOneShot(audioClip);
    }

    public void UpdateAmmo(int ammo)
    {
        AmmoTextbox.text = AmmoTextPrefix + ammo;
    }

    public void UpdateHealth(int health)
    {
        if (health <= 0 && !isGameLose)
        {
            health = 0;
            //SetGameWin(false);
            isGameOver = true;
            SetGameLose(true);
            GameLose.SetActive(true);
            HealthTextbox.text = "Health: 0";
            return;
        }

        HealthTextbox.text = HealthTextPrefix + health;
    }

    public void UpdateTimeLeft()
    {
        if (RoundTime <= 0)
        {
            RoundTime = 0;
            TimeLeftTextbox.text = TimeLeftTextPrefix + "\n00:00:00";

            //SetGameWin(false);
            isGameOver = true;
            SetGameLose(true);
            GameLose.SetActive(true);
            return;
        }

        RoundTime -= Time.deltaTime;

        int minutes = (int)RoundTime / 60;
        int seconds = (int)RoundTime - 60 * minutes;
        int milliseconds = (int)(100 * (RoundTime - minutes * 60 - seconds));
        
        TimeLeftTextbox.text = TimeLeftTextPrefix + '\n' + string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }

    public void SetGameWin(bool isWin) 
    {

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("FPSPlayer").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        isGameOver = true;
        GameWin.SetActive(true);
        
        if (isWin)
        {
            audioSource.PlayOneShot(GameWinSound);
        }

    }

    public void SetGameLose(bool isLose)
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GameObject.Find("FPSPlayer").GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().enabled = false;
        isGameOver = true;
        isGameLose = true;
        GameLose.SetActive(true);

            if (isLose)
            {
                audioSource.PlayOneShot(GameLoseSound);
            }
    }



    public void ResetGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public int GetScore()
    {
        return score;
    }


    public void Quit()
    {
        Application.Quit();
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene("L2");
    }
}
