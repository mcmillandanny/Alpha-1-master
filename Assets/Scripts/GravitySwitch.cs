using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravitySwitch : MonoBehaviour {

    private Rigidbody2D rb;
    private bool top;
    private PlayerController player;
    public Animator animator;
    
    private void Start()
    {
        player = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            rb.gravityScale *= -1;
            animator.SetBool("isJumping", true);
            Rotation();
            
        }

    }



    void Rotation(){
       
    
        top = !top;
        Flip();
    }

    void Flip()
    {
        Vector3 Scaler = transform.localScale;
        Scaler.y *= -1;
        transform.localScale = Scaler;
    }

}


