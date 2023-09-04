using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ViewEnemy : MonoBehaviour
{
    [SerializeField] private ModelEnemy m_Enemy;
    public ModelEnemy modelEnemy => m_Enemy;
    protected MovesEnemy movesEnemy;

    protected bool moveRight = true;

    public Transform groundDetection;
    public Rigidbody2D rb;

    [SerializeField] private Transform[] m_Points;
    protected Transform[] Points => m_Points;

    protected int index = 0;

    public float m_CurrentHealthPoint;
    protected float speed;
    private float m_Timer;
    public float Timer
    {
        get { return m_Timer; }
        set { m_Timer = value; }
    }

    private void Start()
    {
        movesEnemy = m_Enemy.m_EnemyMoves;
        m_CurrentHealthPoint = m_Enemy.m_MaxHealthPoint;
        speed = m_Enemy.m_Speed;
    }
    private void Update()
    {
        if (movesEnemy == MovesEnemy.DefaultMoves)
        {
            MoveInPlane();
        }
        if (movesEnemy == MovesEnemy.Patrol)
        {
            PatrolPointMove();
        }
        if (movesEnemy == MovesEnemy.SearchObject)
        {
            SearchObject();
        }
        if (rb.velocity.magnitude > m_Enemy.m_MaxSpeed) { rb.velocity = rb.velocity.normalized * m_Enemy.m_MaxSpeed; }
        if (speed > m_Enemy.m_MaxSpeed) { speed = m_Enemy.m_MaxSpeed; }

        if (m_Timer < 0)
        {
            m_Timer = 0;
            return;
        }
        m_Timer -= Time.deltaTime;
    }

    protected abstract void MoveInPlane();
    protected abstract void PatrolPointMove();
    protected abstract void SearchObject();
    protected abstract void FireDamage();
    protected abstract void Freezing();




}
