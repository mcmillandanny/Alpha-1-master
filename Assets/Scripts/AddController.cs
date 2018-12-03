using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddController : MonoBehaviour {

    //public float startShootingDistance;
    public GameObject startShootingTrigger;
    public GameObject explosion;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject EnemyBullet;
    private Transform player;
    public int health;
    public bool isShooting;

    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShots = startTimeBtwShots;
        startShootingTrigger = GameObject.FindGameObjectWithTag("Start Shooting");
        isShooting = false;
	}

    // Update is called once per frame
    void Update()
    {

        if (isShooting == true)
        {
            ShootPlayer();
        }

        //if (Vector2.Distance(transform.position, player.position) > startShootingDistance)
        //{
        //    ShootPlayer();
        //}

        //if (timeBtwShots <= 0)
        //{
        //    Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        //    timeBtwShots = startTimeBtwShots;
        //}
        //else
        //{
        //    timeBtwShots -= Time.deltaTime;
        //}


        if (health <= 0)
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D startShootingTrigger)
    {
        isShooting = true;
    }

    public void ShootPlayer(){
        if (timeBtwShots <= 0)
        {
                Instantiate(EnemyBullet, transform.position, Quaternion.identity);
                timeBtwShots = startTimeBtwShots;
        } else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
