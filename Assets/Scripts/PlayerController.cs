using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public float jump;
    private float moveInput;
    


    private Rigidbody2D rb;
    public bool facingRight = true;


    private bool isGrounded;

    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;


    public int extraJumpsValue;
    private int extraJumps;


    public Animator animator;


    private void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();

}

    private void FixedUpdate()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {

            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {

            Flip();
        }
    }
  
    private void Update()
    {
        if(isGrounded == true){
            extraJumps = extraJumpsValue;
            animator.SetBool("isJumping", false);

        }

        animator.SetFloat("Speed", Mathf.Abs(moveInput));

        if(Input.GetKeyDown(KeyCode.W) && extraJumps > 0){
            rb.velocity = Vector2.up * jump;
            animator.SetBool("isJumping", true);
            extraJumps--;
            print("jump");
        } else if(Input.GetKeyDown(KeyCode.W) && extraJumps == 0 && isGrounded == true){
            rb.velocity = Vector2.up * jump;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Quit the game");
            Application.Quit();
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
