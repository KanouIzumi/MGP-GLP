﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartBtn() 
    {
        SceneManager.LoadScene("Main Game");
    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Level 2");
    }

}
