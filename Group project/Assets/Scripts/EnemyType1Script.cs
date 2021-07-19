using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyType1Script : MonoBehaviour
{
    public int enemyHP;

    public float contactDistance;
    public float damageRate;

    private NavMeshAgent navMeshAgent;
    private GameObject player;
    private Transform playerTransform;


    [Tooltip("Sound upon death")]
    public AudioClip DeathAudioClip;

    [Tooltip("Score reward for destorying enemy")]
    public int ScoreReward;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.isStopped = true;


    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        //Debug.Log(distanceToPlayer);

        if (distanceToPlayer < contactDistance)
        {
            if (navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = false;
            }

            navMeshAgent.SetDestination(player.transform.position);
        }
        else
        {
            if (!navMeshAgent.isStopped)
            {
                navMeshAgent.isStopped = true;
            }
        }
    }



    public void OnHit(int damage)
    {
       enemyHP -= damage;

        if (enemyHP <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        GameManager.Instance.UpdateScore(ScoreReward, DeathAudioClip);
        Destroy(gameObject);
    }

}

