using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [Tooltip("Sound when Target is shot")]
    public AudioClip DeathAudioClip;

    [Tooltip("Health of the target")]
    public int HealthPoint;

    [Tooltip("Score reward for destorying enemy")]
    public int ScoreReward;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnHit(int damage)
    {
        GameManager.Instance.targetCount(ScoreReward, DeathAudioClip);
        Destroy(gameObject);
    }
}
