using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoSingleton<Player>
{
    [SerializeField] private float m_MaxHealthPoint = 100;
    public float MaxHealthPoint => m_MaxHealthPoint;
    [SerializeField] private float m_CurrentHealthPoint = 100;
    [SerializeField] private GameObject m_WindowYouLose;
    public float CurrentHealthPoint
    {
        get
        {
            return m_CurrentHealthPoint;
        }
        set
        {
            m_CurrentHealthPoint = value;
            if (m_CurrentHealthPoint > m_MaxHealthPoint) m_CurrentHealthPoint = m_MaxHealthPoint;
        }
    }

    [SerializeField] private float m_MaxManaPoint = 100;
    public float MaxManaPoint => m_MaxManaPoint;
    [SerializeField] private float m_CurrentManaPoint = 100;
    public float CurrentManaPoint
    {
        get
        {
            return m_CurrentManaPoint;
        }
        set
        {
            m_CurrentManaPoint = value;
            if (m_CurrentManaPoint > m_MaxManaPoint) m_CurrentManaPoint = m_MaxManaPoint;
        }
    }



    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<ControllerEnemy>())
        {
            if (collision.gameObject.GetComponent<ControllerEnemy>().Timer == 0)
            {
                m_CurrentHealthPoint -= collision.gameObject.GetComponent<ControllerEnemy>().modelEnemy.m_Damage;
                collision.gameObject.GetComponent<ControllerEnemy>().Timer = collision.gameObject.GetComponent<ControllerEnemy>().modelEnemy.m_ShotPeriod;
            }

        }
        if (m_CurrentHealthPoint <= 0)
        {
            m_CurrentHealthPoint = 0;
            m_WindowYouLose.SetActive(true);
            gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Shot>())
        {
            if (collision.gameObject.GetComponent<Shot>().m_IsBomb == true)
            {
                m_CurrentHealthPoint -= collision.gameObject.GetComponent<Shot>().m_Damage;
            }
        }
    }
    private void OnDestroy()
    {
        if (m_CurrentHealthPoint <= 0) Destroy(gameObject);
    }
}
