using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Boss : MonoBehaviour {

    public int health;
    public GameObject explosion;
    public Slider healthBar;
    public GameObject firewall;
    private float timeBtwFireWallsFirst;
    public float startTimeBtwFireWallsFirst;
    private float timeBtwFireWallsSecond;
    public float startTimeBtwFireWallsSecond;
    public GameObject leftPoint;
    public GameObject rightPoint;
    public SpriteRenderer puddle;
    public GameObject winScreen;


    // Use this for initialization
    void Start () {

        timeBtwFireWallsFirst = startTimeBtwFireWallsFirst;
        timeBtwFireWallsSecond = startTimeBtwFireWallsSecond;
        leftPoint = GameObject.FindGameObjectWithTag("LeftPoint");
        puddle.enabled = false;



    }

    // Update is called once per frame
     void Update(){

        healthBar.value = health;

        if (health <= 30){
            transform.localEulerAngles = new Vector3(0f, 180f, 0f);
            gameObject.transform.position = leftPoint.transform.position;

        }



        if (health <= 25){

            if (timeBtwFireWallsFirst <= 0){
                Instantiate(firewall, transform.position, Quaternion.identity);
                timeBtwFireWallsFirst = startTimeBtwFireWallsFirst;
            } else {
                timeBtwFireWallsFirst -= Time.deltaTime;
            }
        }


        if (health <= 20) {
            transform.localEulerAngles = new Vector3(0f, 0f, 0f);
            gameObject.transform.position = rightPoint.transform.position;
            puddle.enabled = true;
        }



        if (health <= 15)
        {

            if (timeBtwFireWallsSecond <= 0)
            {
                Instantiate(firewall, transform.position, Quaternion.identity);
                timeBtwFireWallsSecond = startTimeBtwFireWallsSecond;
            }
            else
            {
                timeBtwFireWallsSecond -= Time.deltaTime;
            }
        }


        if (health <= 0){
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            winScreen.SetActive(true);
        }

        
     }
    
    public void TakeDamage(int damage){
        health -= damage;
    }

}
