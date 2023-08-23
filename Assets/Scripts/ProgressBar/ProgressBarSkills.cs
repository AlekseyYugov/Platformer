using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBarSkills : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private MagicProjectile projectile;
    private Turret turret;
    public float value;

    private void Start()
    {
        turret = FindAnyObjectByType<Turret>();
        value = turret.m_Timer;
    }

    
    

    private void Update()
    {
        if (turret.projectile[turret.index] == projectile)
        {       
            if(turret.m_Timer == 0)value= 0;
        }
        image.fillAmount = value / projectile.m_ShotPeriod;
        value += Time.deltaTime;
    }


}
