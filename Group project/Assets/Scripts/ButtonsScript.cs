using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene("L1");
    }

    public void Back()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("");
    }
}
