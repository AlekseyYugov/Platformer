using System.Collections;
using UnityEngine;

public class ControllerEnemy : ViewEnemy
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GameObject m_NextLevel;
    [SerializeField] private GameObject m_Progressbar;
    private Shot shot;
    private float CurrentTimer;
    private float newSpeed;

    private bool fire = false;
    private bool ice = false;

    public bool onGround;
    private float checkRadius = 0.5f;
    public LayerMask Ground; 
    public Transform groundCheck;



    private void FixedUpdate()
    {
        if (m_CurrentHealthPoint < modelEnemy.m_MaxHealthPoint)
        {
            m_CurrentHealthPoint += Time.deltaTime;
        }
        if (m_CurrentHealthPoint > modelEnemy.m_MaxHealthPoint) m_CurrentHealthPoint = modelEnemy.m_MaxHealthPoint;

        if (fire)
        {
            ice = false;
            FireDamage();

        }
        if (ice)
        {
            fire = false;
            Freezing();
        }
        CheckingGround();
        if (jump) 
        {
            //gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10000f, ForceMode2D.Impulse);
            StartCoroutine(Jump());
            jump= false;
            
        }
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<Shot>()) return;
        movesEnemy = MovesEnemy.SearchObject;

        shot = collision.gameObject.GetComponent<Shot>();

        m_CurrentHealthPoint -= shot.m_Damage;

        if (m_CurrentHealthPoint <= 0)
        {
            if (modelEnemy.m_BigBoss == true)
            {
                m_NextLevel.SetActive(true);
            }            
            Destroy(gameObject);
        }

        CurrentTimer = shot.m_Timer;

        if (speed < newSpeed)
        {
            speed = newSpeed;
        }

        if (shot.m_IsFire == true)
        {
            fire = true;
            ice = false;
        }
        if (shot.m_IsIce == true)
        {
            newSpeed = speed;
            ice = true;
            fire = false;
        }
        
    }

    protected override void MoveInPlane()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= modelEnemy.m_DistanceToThePlayer) movesEnemy= MovesEnemy.SearchObject;
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, modelEnemy.m_DistanceToMove);
            if (groundInfo.collider == false)
            {
                IsRight();
            }
        }
    }

    protected override void PatrolPointMove()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= modelEnemy.m_DistanceToThePlayer) movesEnemy = MovesEnemy.SearchObject;
        else
        {
            if (transform.position.x > Points[index].position.x)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
                m_Animator.SetBool("Right", false);
                m_Progressbar.transform.localScale = new Vector3(1,1,1);
            }
            if (transform.position.x < Points[index].position.x)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                m_Animator.SetBool("Right", true);
                m_Progressbar.transform.localScale = new Vector3(-1, 1, 1);
            }
            if (Vector2.Distance(transform.position, Points[index].position) <= 1f)
            {
                index++;
            }
            if (index == Points.Length)
            {
                index = 0;
            }
        }

    }

    private bool jump = false;
    protected override void SearchObject()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, modelEnemy.m_DistanceToMove);
        if(groundInfo.collider != null)
        {
            if (groundInfo.collider.tag == "Raise")
            {
                if(onGround)
                {                    
                    jump = true;
                }
            }
        }
        
        
        
        if (transform.position.x > Player.Instance.transform.position.x)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            m_Animator.SetBool("Right", false);
            m_Progressbar.transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            m_Animator.SetBool("Right", true);
            m_Progressbar.transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    IEnumerator Jump()
    {
        var rb = gameObject.GetComponent<Rigidbody2D>();
        var pos = rb.position;
        while (true)
        {
            rb.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
            if(rb.position.y > pos.y +1f)
            {
                yield break;
                

            }
            yield return null;

        }

    }
    private bool IsRight()
    {
        if (moveRight == true)
        {
            gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
            moveRight = false;
            return moveRight;
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            moveRight = true;
            return moveRight;
        }
    }
    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
    }
    protected override void FireDamage()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        if (CurrentTimer > 0)
        {
            CurrentTimer -= Time.deltaTime;
            m_CurrentHealthPoint -= shot.m_CurrentFireDamage;
            if (m_CurrentHealthPoint <= 0) Destroy(gameObject);
        }
        else
        {
            fire = false;
            CurrentTimer = shot.m_Timer;
        }
    }

    protected override void Freezing()
    {
        if (CurrentTimer > 0)
        {
            CurrentTimer -= Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
            speed = newSpeed /2;
        }
        else
        {
            ice = false;
            CurrentTimer = shot.m_Timer;
            gameObject.GetComponent<SpriteRenderer>().color = Color.white;
            speed  = newSpeed * 2;
        }
    }
}
