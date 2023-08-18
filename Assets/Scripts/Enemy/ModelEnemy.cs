using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum MovesEnemy
{
    DefaultMoves,
    Patrol,
    SearchObject
}

[CreateAssetMenu]
public class ModelEnemy : ScriptableObject
{
    public MovesEnemy m_EnemyMoves;
    public float m_Speed = 2f;
    public float m_DistanceToMove = 5f;
    public float m_DistanceToThePlayer = 5f;
    public float m_MaxSpeed = 2f;
    public float m_MaxHealthPoint = 100f;
    public float m_Damage = 10;
    public float m_ShotPeriod = 0.5f;
    public RuntimeAnimatorController m_Animator;
}
