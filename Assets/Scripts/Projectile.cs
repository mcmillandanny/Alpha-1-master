using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;
    public float lifeTime;
    public float distance;
    public int damage;
    public LayerMask bossLayer;
    public PlayerController player;
    public GameObject particle;
    public float partileLifeTime = 2f;
    private Vector2 bulletDirection;


    // Use this for initialization
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
        GameObject playerObj = GameObject.Find("Player");
        player = playerObj.GetComponent<PlayerController>();

        if (!player.facingRight)
        {
            Debug.Log("right");
            bulletDirection = Vector2.right;
        }

        else
        {
            Debug.Log("left");
            bulletDirection = -Vector2.right;
        }

    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, bossLayer);

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Boss"))
            {
                hitInfo.collider.GetComponent<Boss>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Add"))
            {
                hitInfo.collider.GetComponent<AddController>().TakeDamage(damage);
            }
            DestroyProjectile();
        }

        transform.Translate(bulletDirection * speed * Time.deltaTime);

    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
