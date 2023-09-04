using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerOpenGameObjects : MonoBehaviour
{
    [SerializeField] List<GameObject> m_Object;

    private void Start()
    {
        for (int i = 0; i < m_Object.Count; i++)
        {
            m_Object[i].SetActive(false);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>())
        {
            for (int i = 0; i < m_Object.Count; i++)
            {
                m_Object[i].SetActive(true);
            }
        }
        
    }
}
