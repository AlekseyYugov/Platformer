using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;




public class Shot : MonoBehaviour
{
    [SerializeField] private GameObject m_Character;
    [SerializeField] private GameObject cursor;
    [SerializeField] private AudioSource audioSource;

    public float m_Damage = 10;
    public bool m_IsIce;
    public bool m_IsFire;
    public bool m_IsBomb;
    public float m_CurrentFireDamage = 5f;
    public float m_Timer = 3f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() || collision.gameObject.GetComponent<CursorPosition>()) return;
        if (m_IsBomb == false) Delete(0);

        //if (m_Character.name == collision.name || gameObject.name == collision.name) return;
        //else Delete(0);

    }
    private void Start()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + 180);
        if(m_IsBomb == true)
        {            
            Delete(1f);
        }
        else
        {
            Delete(5);
        }
        audioSource.Play();
    }
    private void Delete(float time)
    {
        Destroy(this.gameObject, time);
    }

}
