using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UIElements;


public class NewMonoBehaviourScript : MonoBehaviour
{
    public float moveSpeed = 3f;
    Animator playerAnimator;
    public Rigidbody2D rb;
    public float jumpSpeed = 3f, jumpFrequency = 1f, nextJumpTime;

    public Transform groundCheckPosition;
    public float groundCheckRadius;
    public LayerMask groundCheckLayer;


    


    bool facingRight = true;
    public bool isGrounded = false;
    


    void Awake() 
    {

    }
    void Start()
    {
        transform.localScale = new Vector3(0.5f, 0.5f, 0f);

        rb = GetComponent<Rigidbody2D>(); // take Rigidbody 
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            
            HorizontalMove();
            onGroundCheck();

        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        rb.linearVelocity = new UnityEngine.Vector2(moveX , rb.linearVelocityY);

        if(rb.linearVelocityX < 0 && facingRight) 
        {
            FlipFace();
        }
        else if (rb.linearVelocityX > 0 && !facingRight) 
        {
            FlipFace();
        }


        if(Input.GetAxis("Vertical") > 0 && isGrounded && (nextJumpTime < Time.timeSinceLevelLoad)) 
        {
            nextJumpTime = Time.timeSinceLevelLoad + jumpFrequency;
            Jump();
            
        }
    }
    
    void FixedUpdate()
    {
       
    }

    void HorizontalMove() 
    {
        float moveX = Input.GetAxis("Horizontal") * moveSpeed;
        rb.linearVelocity = new UnityEngine.Vector2(moveX , rb.linearVelocityY);

         playerAnimator.SetFloat("PlayerSpeed", Mathf.Abs(rb.linearVelocityX));

        
    }

    void FlipFace() 
    {
        facingRight = !facingRight;
        UnityEngine.Vector3 tempLocalScale = transform.localScale;
        tempLocalScale.x *= -1f;
        transform.localScale = tempLocalScale;

    }

    void Jump() 
    {
        rb.AddForce(new Vector2(0f, jumpSpeed));
    }

    void onGroundCheck() 
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPosition.position, groundCheckRadius, groundCheckLayer);
        playerAnimator.SetBool("isGroundedAnim", isGrounded);
    }
}
