using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents game_event;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        //creating instance
        game_event = this;
    }

    //Event Actin
    public event Action OnDorrwayTriggerEnter;
    public event Action OnDorrwayTriggerExit;

    //Trigger Method
    public void DoorwayTriggerEnter()
    {
        if(OnDorrwayTriggerEnter != null)
        {
            OnDorrwayTriggerEnter();
        }
    }

    public void DoorwayTriggerExit()
    {
        if (OnDorrwayTriggerExit != null)
        {
            OnDorrwayTriggerExit();
        }
    }

}
