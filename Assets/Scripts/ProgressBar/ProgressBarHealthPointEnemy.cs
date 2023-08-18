using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarHealthPointEnemy : MonoBehaviour
{
    [SerializeField] private Image progressbar;
    [SerializeField] private Image back;
    [SerializeField] private ControllerEnemy enemy;// измен€ю Enemy на ControllerEnemy
    
    private void Update()
    {
        transform.eulerAngles = new Vector3(0, 0, 0);
        progressbar.fillAmount = enemy.m_CurrentHealthPoint / enemy.modelEnemy.m_MaxHealthPoint;
        if (enemy.m_CurrentHealthPoint == enemy.modelEnemy.m_MaxHealthPoint)
        {
            progressbar.enabled = false;
            back.enabled = false;
        }
        else
        {
            progressbar.enabled = true;
            back.enabled = true;
        }
    }
}
