using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform cursor;

    [SerializeField] private MagicProjectile projectile;

    public static float m_Timer;

    private void Update()
    {
        m_Timer += Time.deltaTime;
        Vector2 turret = cursor.position - transform.position;
        transform.rotation = Quaternion.LookRotation(turret);
        if (Input.GetMouseButton(0))
        {            
            if (m_Timer > projectile.m_ShotPeriod)
            {
                m_Timer = 0;
                GameObject shot = Instantiate(projectile.m_MagicGunPrefab, transform.position, Quaternion.identity);
                shot.GetComponentInChildren<Rigidbody2D>().velocity = transform.forward * projectile.m_SpeedProjictile;
            }
        }
    }
}
