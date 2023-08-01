using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject m_Character;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_Character.name == collision.name || gameObject.name == collision.name) return;
        else Destroy(this.gameObject);

    }

}
