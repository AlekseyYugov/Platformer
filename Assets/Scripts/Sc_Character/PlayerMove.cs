using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    //public Animator anim;
    private bool faceRight = true;
    public float jumpForce = 7f;
    private bool jumpControl = true;
    private int jumpValueIteration = 60;

    public bool onGround;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;

    private void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        //anim= GetComponent<Animator>();
    }
    private void Update()
    {
        
        if (!Input.GetMouseButton(0) || jumpCount != 0)
        {
            
        }
        Walk();
        Reflect();
        Jump();
        CheckingGround();
    }

    
    public float speed = 2f;
    private void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        //anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);
    }
    private void Reflect()
    {
        if ((moveVector.x>0&&!faceRight) || (moveVector.x<0&&faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }
    private int jumpCount = 0;
    private int maxJumpValue = 2;

    //void Jump()
    //{
    //    if (Input.GetKey(KeyCode.Space))
    //    {
    //        if (onGround)
    //        {
    //            jumpControl = true;
    //        }
    //    }
    //    else
    //    {
    //        jumpControl = false;
    //    }
    //    if (jumpControl)
    //    {
    //        if (jumpIteration++ < jumpValueIteration)
    //        {
    //            rb.AddForce(Vector2.up * jumpForce / jumpIteration);
    //        }
    //    }
    //    else
    //    {
    //        jumpIteration = 0;
    //    }
    //    if (rb.velocity.y == 0)
    //    {
    //        anim.SetBool("zeroVelocityY", true);
    //    }
    //    else
    //    {
    //        anim.SetBool("zeroVelocityY", false);
    //    }
    //}
    private float doubleJumpVelocity = 10f;
    private void Jump()
    {
        if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
        {
            Physics2D.IgnoreLayerCollision(9, 10, true);
            Invoke("IgnoreLayerOff", 0.5f);
            jumpControl = false;
        }
        if (jumpControl)
        {
            if (onGround) { jumpCount = 0; }
            if (Input.GetKeyDown(KeyCode.Space) && onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, 0);
                rb.AddForce(Vector2.up * jumpForce * 50);
            }

            if (Input.GetKeyDown(KeyCode.Space) && !onGround && (++jumpCount < maxJumpValue))
            {
                rb.velocity = new Vector2(0, doubleJumpVelocity);
            }

            //if (rb.velocity.y == 0)
            //{
            //anim.SetBool("zeroVelocityY", true);
            //}
            //else
            //{
            //anim.SetBool("zeroVelocityY", false);
            //}
        }
    }


    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
        //anim.SetBool("onGround", onGround);
    }
    private void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(9, 10, false);
        jumpControl = true;
    }
}
