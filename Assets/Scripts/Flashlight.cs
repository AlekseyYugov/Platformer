using UnityEngine;

public class Flashlight : MonoBehaviour
{
    [SerializeField] private GameObject m_Light;
    [SerializeField] private bool m_Activate;
    private Shot shot;

    private void Start()
    {
        if(m_Activate)
        {
            m_Light.SetActive(true);
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
            m_Light.SetActive(false);
        }
        
    }
    
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
