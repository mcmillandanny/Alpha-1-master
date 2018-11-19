using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 1;
    public Rigidbody2D rb;
    public GameObject impactEffect;

    // Use this for initialization
    void Start()
    {
        //rb.velocity = transform.right * speed;


    }

    void Update(){
        PlayerController player = gameObject.GetComponent<PlayerController>();
        if (player.facingRight == true)
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("left");
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo){
        Boss enemy = hitInfo.GetComponent<Boss>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

    }


}