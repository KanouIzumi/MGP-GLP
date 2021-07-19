using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2Script : MonoBehaviour
{
    [Tooltip("Sound upon death")]
    public AudioClip DeathAudioClip;

    [Tooltip("Score reward for destorying enemy")]
    public int ScoreReward;

    public int enemyHP;

    private float timebtwshots;
    public float starttimebtwshots;

    public GameObject projectile;
    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (timebtwshots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timebtwshots = starttimebtwshots;
        }

        else
        {
            timebtwshots -= Time.deltaTime;
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
