using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class MagicProjectile : ScriptableObject
{
    public GameObject m_MagicGunPrefab;
    public float m_SpeedProjictile = 5.0f;
    public float m_ShotPeriod = 0.2f;
}
