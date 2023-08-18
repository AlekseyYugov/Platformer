using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject m_NextTeleport;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            if (collision.gameObject.GetComponent<Player>().m_IsTeleporting == false) 
            {
                collision.gameObject.transform.position = m_NextTeleport.transform.position;
            }
        }
    }
}
