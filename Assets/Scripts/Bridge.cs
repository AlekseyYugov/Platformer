using System.Collections;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private GameObject m_Bridge;
    [SerializeField] private float m_Corner;
    [SerializeField] private float m_MaxCorner;
    [SerializeField] private AudioSource audioSource;
    private float m_SumCorner;
    private Coroutine coroutine;
    private Shot shot;
    private bool cameDown = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Shot>())
        {
            shot= collision.gameObject.GetComponent<Shot>();
            if(shot.m_IsBomb == true)
            {
                cameDown= true;
            }
        }
    }
    private void Update()
    {
        if (cameDown == false) return;

        if (m_SumCorner == m_MaxCorner) return;
        m_SumCorner += m_Corner;

        if (coroutine == null) { coroutine = StartCoroutine(C_Rotate(m_Corner, 5f)); }
    }

    IEnumerator C_Rotate(float angle, float intensity)
    {
        var transBridge = m_Bridge.transform;
        var rotationBridge = transBridge.rotation * Quaternion.Euler(0, 0, angle);
        audioSource.Play();
        while(true)
        {
            transBridge.rotation = Quaternion.Lerp(transBridge.rotation, rotationBridge, intensity * Time.deltaTime);

            if (Quaternion.Angle(transBridge.rotation, rotationBridge) < 0.01f)
            {
                coroutine = null;
                transBridge.rotation = rotationBridge;
                yield break;
            }
            yield return null;
        }
    }
}
