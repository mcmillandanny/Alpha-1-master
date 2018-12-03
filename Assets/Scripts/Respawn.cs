using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    [SerializeField] Transform spawnPoint;
    DeathManager death;

    void Start()
    {
        death = GameObject.FindGameObjectWithTag("Death Manager").GetComponent<DeathManager>();
    }



    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.CompareTag("Player"))
            col.transform.position = spawnPoint.position;
            death.OnDeath();
    }
}
