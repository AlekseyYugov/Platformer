using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultPanel : MonoBehaviour
{
    [SerializeField] private Text m_Point;
    [SerializeField] private Text m_TimeGame;
    private void Update()
    {
        m_Point.text = PointsGame.m_Points.ToString();
        m_TimeGame.text = TimeSpan.FromSeconds(TimerGame.m_Timer).ToString(@"mm\:ss\.ff");
    }
}
