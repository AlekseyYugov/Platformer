using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GameObject[] prefabs;
    private GameObject drop;
    private bool ChestEnabled = true;
    private bool open = false;

    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Animator.enabled = false;
    }
    private void Update()
    {
        if(open == true) 
        { 
            if(drop!= null)
            {
                drop.transform.position = new Vector2(drop.transform.position.x, drop.transform.position.y + 5f * Time.deltaTime);
                if (drop.transform.position.y > transform.position.y + 1f)
                {
                    open = false;
                    ChestEnabled = false;
                }
            }
            else
            {
                ChestEnabled = false;
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.GetComponent<Shot>())
        {
            if(open == false && ChestEnabled == true)
            {
                m_Animator.enabled = true;
                gameObject.GetComponent<AudioSource>().Play();
                drop = Instantiate(prefabs[Random.Range(0, prefabs.Length)], transform.position, Quaternion.identity);
                open = true;
            }            
        }            
    }
}
