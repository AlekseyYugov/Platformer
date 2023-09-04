using UnityEngine;

public class TakeManey : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Player>())
        {
            Money.m_Money += 1;
            m_AudioSource.Play(); 
            gameObject.GetComponent<SpriteRenderer>().enabled= false;
            gameObject.GetComponent<Animator>().enabled= false;
            gameObject.GetComponent<BoxCollider2D>().enabled= false;

            Destroy(gameObject, 0.2f);
        }
    }
}
