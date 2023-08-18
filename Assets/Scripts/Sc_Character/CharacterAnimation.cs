using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : PlayerController
{
    public Animator anim;
    public PlayerController player;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void MoveChar()
    {
        if (!player.onGround)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if(Input.GetKey(KeyCode.A)) faceRight = false;
            if(Input.GetKey(KeyCode.D)) faceRight = true;
            anim.SetBool("Run", true);

        }
        else
        {
            anim.SetBool("Run", false);
        }

    }

    public void AnimAttack()
    {//TODO
        
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("Attack", true);
        }
    }
    private void Update()
    {
        MoveChar();
        if (Input.GetMouseButton(0) == false)
        {
            anim.SetBool("Attack", false);
        }
    }

    
}
