using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarSkills : MonoBehaviour
{
    [SerializeField] private Image image;

    private float value = Turret.m_Timer;
    [SerializeField] private MagicProjectile projectile;

    private void Update()
    {
        value = Turret.m_Timer;
        if (image != null) 
        {
            image.fillAmount = value / projectile.m_ShotPeriod;
        }
    }


}
