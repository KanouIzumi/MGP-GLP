using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript Instance;

    [Tooltip("Shooting rate of the player")]
    public float ShootingRate;

    [Tooltip("Damage on enemy on each hit")]
    public int ShootingDamage;

    [Tooltip("Damage speed with contact with enemy")]
    public int DamageRate;

    //how often it will damage
    [Tooltip("Damage speed with contact with trap")]
    public int RateOfDamage;


    [Tooltip("Starting health of the enemy")]
    public int HealthPoint;

    [Tooltip("Starting ammo of the enemy")]
    public int AmmoCount;

    [Tooltip("Shooting sound effect")]
    public AudioClip ShootingAudioClip;


    // Reference to muzzle flash //
    public GameObject MuzzleFlash;

    private Rigidbody rb = null;
    private Vector3 moveDirection = Vector3.zero;
    private bool canShoot;
    private bool canDamage;
    private bool canTrapDamage;
    private bool canEnemyDamge;
    private AudioSource audioSource;
    private GameObject camera = null;
    

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

        canShoot = true;
        canDamage = true;
        audioSource.clip = ShootingAudioClip;
        camera = GameObject.FindGameObjectWithTag("MainCamera");

        GameManager.Instance.UpdateAmmo(AmmoCount);
        GameManager.Instance.UpdateHealth(HealthPoint);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
            return;

        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && AmmoCount > 0)
        {
            // Play muzzle flash //
            StartCoroutine(PlayMuzzleFlash(0.05f));

            StartCoroutine(SpawnBullet());
        }
    }

    // Play muzzle flash function //
    private IEnumerator PlayMuzzleFlash(float duration)
    {
        MuzzleFlash.SetActive(true);
        yield return new WaitForSeconds(duration);
        MuzzleFlash.SetActive(false);
    }

    private IEnumerator SpawnBullet()
    {
        RaycastHit hit;

        if (Physics.Raycast(camera.transform.position + camera.transform.forward, camera.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.gameObject.tag.Equals("Enemy"))
            {
                hit.collider.gameObject.GetComponent<EnemyScript>().OnHit(ShootingDamage);

            }

            if(hit.collider.gameObject.tag.Equals("EnemyType1"))
            {
                hit.collider.gameObject.GetComponent<EnemyType1Script>().OnHit(ShootingDamage);
            }

            if (hit.collider.gameObject.tag.Equals("EnemyType2"))
            {
                hit.collider.gameObject.GetComponent<EnemyType2Script>().OnHit(ShootingDamage);
            }

            if (hit.collider.gameObject.tag.Equals("Target"))
            {
                hit.collider.gameObject.GetComponent<TargetScript>().OnHit(ShootingDamage);
            }

        }

        audioSource.PlayOneShot(ShootingAudioClip);

        GameManager.Instance.UpdateAmmo(--AmmoCount);

        canShoot = false;
        //wait for some time
        yield return new WaitForSeconds(ShootingRate);

        canShoot = true;
    }
    public void MinusHP(int health)
    {
        HealthPoint -= health;
        GameManager.Instance.UpdateHealth(HealthPoint);
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag.Equals("Enemy") && canDamage)
        {
            StartCoroutine(GetDamage(collision));
        }

        if (collision.gameObject.tag.Equals("EnemyType1"))
        {
            Debug.Log("Trap enem1");
            StartCoroutine(GotDamage(collision));
        }

        if (collision.gameObject.tag.Equals("EnemyType2"))
        {
            Debug.Log("Trap touch");
            StartCoroutine(GetsDamage(collision));
        }
    }

    private IEnumerator GetDamage(Collider collision)
    {
        EnemyScript enemyScript = collision.gameObject.GetComponent<EnemyScript>();
        HealthPoint -= enemyScript.ContactDamage;
        GameManager.Instance.UpdateHealth(HealthPoint);

        if (HealthPoint <= 0)
        {
            Dead();
        }

        canDamage = false;
        //wait for some time
        yield return new WaitForSeconds(DamageRate);

        canDamage = true;
    }

    private IEnumerator TrapDamage(Collider collision2)
    {
        Spike_Trap spike_Trap = collision2.gameObject.GetComponent<Spike_Trap>();
        HealthPoint -= spike_Trap.ContactTrapDamage;
        GameManager.Instance.UpdateHealth(HealthPoint);

        if (HealthPoint <= 0)
        {
            Dead();
        }

        canTrapDamage = false;
        //wait for some time
        yield return new WaitForSeconds(RateOfDamage);

        canTrapDamage = true;

    }

    //this is for the EnemyType1
    private IEnumerator GotDamage(Collider collision3)
    {
        EnemyType1Script enemyType1Script = collision3.gameObject.GetComponent<EnemyType1Script>();
        HealthPoint -= enemyType1Script.DamageDoneToPlyer;
        GameManager.Instance.UpdateHealth(HealthPoint);
        if (HealthPoint <= 0)
        {
            Dead();
        }

        canEnemyDamge = false;
        //wait for some time
        yield return new WaitForSeconds(DamageRate);

        canEnemyDamge = true;
    }

    //this is for the EnemyType2
    private IEnumerator GetsDamage(Collider collision4)
    {
        EnemyType2Script enemyType2Script = collision4.gameObject.GetComponent<EnemyType2Script>();
        HealthPoint -= enemyType2Script.DamageDoneToPlyer;
        GameManager.Instance.UpdateHealth(HealthPoint);
        if (HealthPoint <= 0)
        {
            Dead();
        }

        canDamage = false;
        //wait for some time
        yield return new WaitForSeconds(DamageRate);

        canDamage = true;
    }



    private void Dead()
    {
        //Destroy(gameObject);
    }

    public void AddAmmo(int ammo, AudioClip audioClip)
    {
        AmmoCount += ammo;
        GameManager.Instance.UpdateAmmo(AmmoCount);

        audioSource.PlayOneShot(audioClip);
    }

    public void AddHealth(int health, AudioClip audioClip)
    {
        HealthPoint += health;
        GameManager.Instance.UpdateHealth(HealthPoint);

        audioSource.PlayOneShot(audioClip);
    }
}
