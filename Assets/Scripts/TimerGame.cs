using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerGame : MonoBehaviour
{
    [SerializeField] private Text m_TimerText;
    public static float m_Timer;
    private void Start()
    {
        m_Timer = 0;
    }
    private void Update()
    {
        m_Timer += Time.deltaTime;
        m_TimerText.text = TimeSpan.FromSeconds(m_Timer).ToString(@"mm\:ss\.ff");
    }
}
