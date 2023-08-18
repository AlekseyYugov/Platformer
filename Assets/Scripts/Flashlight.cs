using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject m_Light;

    private void Start()
    {
        m_Light.SetActive(false);
    }

    private Shot shot;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Shot>())
        {
            shot = collision.gameObject.GetComponent<Shot>();
            if (shot.m_IsFire == true)
            {
                gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                m_Light.SetActive(true);

            }
        }
    }
}
