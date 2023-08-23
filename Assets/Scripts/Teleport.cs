using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport m_NextTeleport;
    public bool m_IsTeleporting = false;
    //private void OnTriggerStay2D(Collider2D collision)
    //{

    //    if (collision.gameObject.GetComponent<Player>())
    //    {
    //        if (collision.gameObject.GetComponent<Player>().m_IsTeleporting == true)
    //        {
    //            collision.gameObject.transform.position = new Vector2(m_NextTeleport.transform.position.x, m_NextTeleport.transform.position.y + 5f);
    //        }
    //    }
    //}
    //private void OnTriggerExit2D(Collider2D collision)
    //{

    //    if (collision.gameObject.GetComponent<Player>())
    //    {
    //        if (collision.gameObject.GetComponent<Player>().m_IsTeleporting == true)
    //        {
    //            Player.Instance.m_IsTeleporting = false;
    //        }
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_IsTeleporting == true) return;
        if(collision.GetComponent<Player>())
        {
            m_NextTeleport.m_IsTeleporting = true;

            Player.Instance.transform.position = m_NextTeleport.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<Player>()) { m_IsTeleporting = false; }
    }
}
