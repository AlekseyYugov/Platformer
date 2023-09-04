using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Teleport m_NextTeleport;
    public bool m_IsTeleporting = false;

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
