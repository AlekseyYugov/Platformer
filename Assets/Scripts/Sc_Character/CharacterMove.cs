using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMove : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = true;


    [SerializeField] protected float speed;
    //[SerializeField] private Camera main_camera;

    //[SerializeField] private BoxCollider2D triggerBack;
    protected bool activateTrigger = false;

    private bool jumpControl;
    private int jumpIteration = 0;
    public int jumpValueIteration = 60;


    private void Start()
    {
        playerRb= GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;
    }
    void Update()
    {
        //main_camera.transform.position = new Vector3(playerRb.transform.position.x + 5f, main_camera.transform.position.y, main_camera.transform.position.z);
        MoveChar();
    }
    protected virtual void MoveChar()
    {
        //if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        //{
        //    playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);

        //    isOnGround = false;
        //}
        Jump();
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        
    }


    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (isOnGround) 
            { 
                jumpControl = true; 
                
            }
            
        }
        else
        {
            jumpControl = false;
        }
        if (jumpControl)
        {
            if (jumpIteration ++ < jumpValueIteration)
            {
                playerRb.AddForce(Vector2.up * jumpForce / jumpIteration);
            }
        }
        else
        {
            jumpIteration = 0;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        isOnGround = true;

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        activateTrigger= true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        activateTrigger= false;
    }
}
