using UnityEngine;

public enum TypeProjectilePlayer
{
    Default,
    Fire,
    Ice,
    Bomb
}

[CreateAssetMenu]
public class MagicProjectile : ScriptableObject
{
    public GameObject m_MagicGunPrefab;
    public TypeProjectilePlayer typeProjectile;
    public float m_SpeedProjictile = 5.0f;
    public float m_ShotPeriod = 0.2f;
    public float m_TakeMana = 10f;
}
