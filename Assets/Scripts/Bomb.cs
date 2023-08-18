using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Animator m_Anim;
    [SerializeField] private GameObject m_Projectile;
    [SerializeField] private GameObject m_Light;

    private float timer = 0;

    private Shot shot;
    private bool currentFire = false;


    

    private void Start()
    {
        
        m_Anim.enabled= false;
        m_Light.SetActive(false);
        gameObject.transform.localScale = new Vector3(1f, 1f, -1f);
    }
    private void Update()
    {
        
        if (m_Anim.enabled == true)
        {
            timer += Time.deltaTime;
        }
        Delete();

        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Shot>())
        {
            shot= collision.gameObject.GetComponent<Shot>();
            if(shot.m_IsFire == true)
            {
                if(currentFire == false) {timer = 0; currentFire= true;}
                m_Anim.enabled = true;
                m_Light.SetActive(true);
                
                Delete();
            }
        }
    }

    
    private void Delete()
    {

        if(timer >= 5)
        {
            Instantiate(m_Projectile, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
