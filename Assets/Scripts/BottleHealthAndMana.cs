using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleHealthAndMana : MonoBehaviour
{
    [SerializeField] private float m_Health = 0;
    [SerializeField] private float m_Mana = 0;
    [SerializeField] private AudioSource audioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Player.Instance.CurrentHealthPoint += m_Health;
            Player.Instance.CurrentManaPoint += m_Mana;
            audioSource.Play();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 0.2f);
        }
    }
}
