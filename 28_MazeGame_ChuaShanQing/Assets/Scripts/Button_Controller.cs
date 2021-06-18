using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Controller : MonoBehaviour
{
    public void OnRestart()
    {
        SceneManager.LoadScene("Maze_Level1");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
