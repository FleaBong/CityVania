using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{

    [Header("Jump Details")]
    public float jumpforce;
    public float jumpTime;
    private float jumpTimeCounter;
    private bool stoppedJumping;

    [Header("Ground Details")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radOCircle;
    [SerializeField] private LayerMask whatIsGround;
    public bool grounded;


    [Header("Components")]
    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpTimeCounter = jumpTime;
    }

    private void Update()
        //what it means to be grounded
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position,radOCircle,whatIsGround);

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }


        //if we press jump button
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //jump !!
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            stoppedJumping = false;
        }

        //if we hold jump button
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0) )
        {
                      //jump !!
            rb.velocity = new Vector2(rb.velocity.x, jumpforce);
            jumpTimeCounter -= Time.deltaTime;
            
        }

        //if we release the jump button
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true; 
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(groundCheck.position, radOCircle);
    }

   
}
