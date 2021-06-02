using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEvents : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //Referencing to GameEvents Script
        GameEvents.game_event.OnDorrwayTriggerEnter += OnDoorWayOpen;

        GameEvents.game_event.OnDorrwayTriggerExit += OnDoorWayClose;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDoorWayOpen()
    {
        this.transform.position = new Vector3(0.43f, 3, 0);
    }

    private void OnDoorWayClose()
    {
        this.transform.position = new Vector3(0.43f, 0, 0);
    }
}
