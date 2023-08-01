using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : CharacterMove
{
    public Animator anim;
    private bool faceRight = true;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    protected override void MoveChar()
    {
        anim.SetBool("Jump", false);
        anim.SetBool("RunRight", false);
        anim.SetBool("RunLeft", false);
        anim.SetBool("JumpBack", false);
        if (faceRight)
        {
            anim.SetBool("IdleBack", false);
        }
        else 
        { 
            anim.SetBool("Idle", false); 
        }
        if (Input.GetKeyDown(KeyCode.Space) && faceRight)
        {
            anim.SetBool("Jump", true);
        }
        if (Input.GetKeyDown(KeyCode.Space) && !faceRight)
        {
            anim.SetBool("JumpBack", true);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            faceRight = true;
            anim.SetBool("RunRight", true);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            faceRight= false;
            anim.SetBool("RunLeft", true);

        }



    }
    private void Update()
    {
        MoveChar();
    }

    
}
