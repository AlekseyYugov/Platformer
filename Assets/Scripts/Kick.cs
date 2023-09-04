using UnityEngine;
using UnityEngine.UI;

public class Kick : MonoBehaviour
{
    [SerializeField] private float MaxHeight = 1.5f;
    [SerializeField] private float speed = 5;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float m_Timer = 5f;
    [SerializeField] private Image m_Image;
    public GameObject cursor;    
    private Vector2 startPosition;
    private Vector2 endPosition;
    private bool kick = false;
    private float m_Time;
    private RaiseObject raiseObject;

    private void Start()
    {
        m_Time = m_Timer;
    }

    void Update()
    {
        m_Time += Time.deltaTime;
        if(m_Time >= m_Timer) m_Time = m_Timer;
        m_Image.fillAmount = m_Time / m_Timer;
        
        if (Input.GetMouseButtonDown(1))
        {
            if (CursorPosition.triggerObject != null)
            {
                if (CursorPosition.triggerObject.tag == "Raise")
                {
                    if (Vector2.Distance(Player.Instance.transform.position, CursorPosition.triggerObject.transform.position) > 2f) return;
                    if (CursorPosition.triggerObject.GetComponent<RaiseObject>().onAbove == false && m_Time >= m_Timer)
                    {
                        raiseObject = CursorPosition.triggerObject.GetComponent<RaiseObject>();
                        m_Time = 0;
                        startPosition = raiseObject.transform.position;
                        endPosition = new Vector2(startPosition.x, startPosition.y + MaxHeight);
                        audioSource.Play();
                        kick= true;
                    }
                }
            }
        }
        if(kick == true)
        {
            if (raiseObject.transform.position.y >= endPosition.y) { kick = false; return; }
            else { Raise(); }
            
        }
    }

    private void Raise()
    {
        raiseObject.transform.position = new Vector2(raiseObject.transform.position.x, raiseObject.transform.position.y + speed * Time.deltaTime);
    }
}


