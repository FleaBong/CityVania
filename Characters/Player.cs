using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    private float runSpeed = 2.0f;
    private float walkSpeed = 1.0f;
    public override void Start()
    {
        base.Start();
        speed = runSpeed;
    }
    public override void Update()
    {
        base.Update();
        direction = Input.GetAxisRaw("Horizontal");
        HandleJumping();
    }
    protected override void HandleMovement()
    {
        base.HandleMovement();
        myAnimator.SetFloat("speed", Mathf.Abs(direction));
        TurnAround(direction); 
    }

    protected override void HandleJumping()
    {
        if (grounded)
        {
            jumpTimeCounter = jumpTime;
            myAnimator.ResetTrigger("jump");
            myAnimator.SetBool("falling", false);
        }



        //if we press jump button
        if (Input.GetButtonDown("Jump") && grounded)
        {
            //jump !!
            Jump();
            stoppedJumping = false;
            //tell animator to play jump anim
            myAnimator.SetTrigger("jump");
        }

        //if we hold jump button
        if (Input.GetButton("Jump") && !stoppedJumping && (jumpTimeCounter > 0))
        {
            //jump !!
            Jump();
            jumpTimeCounter -= Time.deltaTime;
            myAnimator.SetTrigger("jump");

        }

        //if we release the jump button
        if (Input.GetButtonUp("Jump"))
        {
            jumpTimeCounter = 0;
            stoppedJumping = true;
            myAnimator.SetBool("falling", true);
            myAnimator.ResetTrigger("jump");
        }
    }
}
