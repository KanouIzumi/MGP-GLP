using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLoseManager : MonoBehaviour
{
    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score: " + PlayerPrefs.GetInt("score");
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
