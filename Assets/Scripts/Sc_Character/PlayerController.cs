using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    protected bool faceRight = true;
    public float jumpForce = 7f;
    private bool jumpControl = true;

    public bool onGround;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask Ground;
    public bool isOnGround = true;

    [SerializeField] private AudioSource audioSource;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        newSpeed = speed;
    }
    private void Update()
    {

        Walk();
        Reflect();
        Jump();
        CheckingGround();
    }


    public float speed = 2f;
    public float newSpeed;
    private Vector2 vector;
    private void Walk()
    {
        moveVector.x = Input.GetAxis("Horizontal");
        vector = moveVector;
        if (onGround && Input.GetMouseButton(0))
        {
            rb.velocity = new Vector2(moveVector.x * 0, rb.velocity.y);
        }
        else { rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y); }
    }
    private void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1, 1, 1));
            faceRight = !faceRight;
        }
    }
    private int jumpCount = 0;
    private int maxJumpValue = 2;


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
                audioSource.Play();
            }

            if (Input.GetKeyDown(KeyCode.Space) && !onGround && (++jumpCount < maxJumpValue))
            {
                rb.velocity = new Vector2(0, doubleJumpVelocity);
                audioSource.Play();
            }
        }
    }


    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
    }
    private void IgnoreLayerOff()
    {
        Physics2D.IgnoreLayerCollision(9, 10, false);
        jumpControl = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }
}
