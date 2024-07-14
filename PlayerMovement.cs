using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMovement : MonoBehaviour
{

    //necessary for animations and physics
    private Rigidbody2D rb2d;
    private Animator myAnimator;

    private bool facingRight = true;


    //variables to play with
    public float speed = 2.0f;
    public float horizMovement;// = 1[OR]-1[OR]0



    // Start is called before the first frame update
    private void Start()
    {
        //define the game objects found on the player
        rb2d = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }




    // Update is called once per frame
    //handles input for physics

    private void Update()
    {
        //check direction given by player
        horizMovement = Input.GetAxisRaw("Horizontal");

    }
    //handles running pyhsics
    private void FixedUpdate()
    {
        //move the character left and right
        rb2d.velocity = new Vector2(horizMovement * speed,rb2d.velocity.y);
        Flip(horizMovement);
        myAnimator.SetFloat("speed", Mathf.Abs(horizMovement));
    }

    //flipping function
    private void Flip(float horizontal)
    {
        if (horizontal < 0 && facingRight || horizontal > 0 && !facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        
    }
}
