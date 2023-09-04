using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsGame : MonoBehaviour
{
    [SerializeField] private Text m_PointsText;
    public static float m_Points;
    void Start()
    {
        m_Points= 0;
    }

    // Update is called once per frame
    void Update()
    {
        m_PointsText.text = "Points: " + m_Points.ToString();
    }
}
