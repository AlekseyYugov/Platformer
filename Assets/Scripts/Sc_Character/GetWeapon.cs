using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class GetWeapon : PlayerMove
{
    //[SerializeField] private GameObject weaponTruncheon;
    //[SerializeField] private GameObject weaponPistolet;
    //[SerializeField] private GameObject weaponMitraillette;

    //private bool truncheon = false;
    //private bool pistolet = false;
    //private bool mitraillette = false;
    //private int indexWeapon = 0;

    public float timeCharge = 0;
    public float timeChargeTruncheon;

    //[SerializeField] private Animator anim;

    private void Update()
    {
        timeCharge += 1f * Time.deltaTime;


        //SelectionWeapon();
        //Attack();


    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (weaponTruncheon.gameObject == collision.gameObject)
    //    {
    //        Destroy(weaponTruncheon);
    //        truncheon = true;
    //    }
    //    if (weaponPistolet.gameObject == collision.gameObject)
    //    {
    //        Destroy(weaponPistolet);
    //        pistolet = true;
    //    }
    //    if (weaponMitraillette.gameObject == collision.gameObject)
    //    {
    //        Destroy(weaponMitraillette);
    //        mitraillette = true;
    //    }
    //}
    //void SelectionWeapon()
    //{
    //    if (Input.GetKeyDown(KeyCode.Keypad1) && truncheon)
    //    {
    //        indexWeapon = 1;
    //        anim.SetInteger("IndexWeapon", indexWeapon);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Keypad2) && pistolet)
    //    {
    //        indexWeapon = 2;
    //        anim.SetInteger("IndexWeapon", indexWeapon);
    //    }
    //    if (Input.GetKeyDown(KeyCode.Keypad3) && mitraillette)
    //    {
    //        indexWeapon = 3;
    //        anim.SetInteger("IndexWeapon", indexWeapon);
    //    }
    //}
    //void Attack()
    //{
    //    if (Input.GetMouseButtonDown(0) && indexWeapon == 0 && Charge() == false)
    //    {
    //        return;
    //    }
    //    if(Input.GetMouseButton(0) && indexWeapon == 1 && Charge() == false)
    //    {
    //        anim.SetBool("AttackTruncheon", true);
    //        rb.velocity = new Vector2(0, 0);
    //        timeCharge = 0;
    //    }
    //    if (Input.GetMouseButtonDown(0) && indexWeapon == 2)
    //    {

    //    }
    //    if (Input.GetMouseButtonDown(0) && indexWeapon == 3)
    //    {

    //    }
    //    if (timeCharge > timeChargeTruncheon)
    //    {
    //        anim.SetBool("AttackTruncheon", false);
    //    }
        
    //}
    //bool Charge()
    //{
    //    if (indexWeapon == 1 && timeCharge > timeChargeTruncheon)
    //    {
    //        return false;
    //    }
    //    return true;
    //}

}
