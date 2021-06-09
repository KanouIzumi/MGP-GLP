using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScript : MonoBehaviour
{
    public void OnRestart()
    {
        SceneManager.LoadScene("GamePlay");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
