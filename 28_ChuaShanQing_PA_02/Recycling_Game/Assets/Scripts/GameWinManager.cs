using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameWinManager : MonoBehaviour
{
    public Text highScoreText;

    // Start is called before the first frame update
    void Start()
    {
       highScoreText.text = "HighScore: " + PlayerPrefs.GetFloat("Highscore", 0f).ToString("0.00");
    }

}
