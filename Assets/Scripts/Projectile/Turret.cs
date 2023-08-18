using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private Transform cursor;

    [SerializeField] private MagicProjectile[] projectile;

    [SerializeField] private CharacterAnimation anim;

    [SerializeField] private AudioSource audioSource;

    private int index = 0;
    public static float m_Timer;

    public static Quaternion rotation;

    private void Update()
    {
        rotation = transform.rotation;
        m_Timer += Time.deltaTime;
        Vector2 turret = cursor.position - transform.position;
        transform.rotation = Quaternion.LookRotation(turret);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;
        }


        if (Input.GetMouseButton(0))
        {
            if (projectile[index].m_TakeMana > Player.Instance.CurrentManaPoint) return;
            if (m_Timer > projectile[index].m_ShotPeriod)
            {
                m_Timer = 0;
                Player.Instance.CurrentManaPoint -= projectile[index].m_TakeMana;
                audioSource.Play();
                anim.AnimAttack();
                GameObject shot = Instantiate(projectile[index].m_MagicGunPrefab, transform.position, Quaternion.identity);
                shot.GetComponentInChildren<Rigidbody2D>().velocity = transform.forward * projectile[index].m_SpeedProjictile;
            }
        }
    }
}
