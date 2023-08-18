using UnityEngine;

public class ControllerEnemy : ViewEnemy
{
    private Shot shot;
    private float CurrentTimer;
    private float newSpeed;

    private bool fire = false;
    private bool ice = false;

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
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<Shot>()) return;

        shot = collision.gameObject.GetComponent<Shot>();

        m_CurrentHealthPoint -= shot.m_Damage;

        if (m_CurrentHealthPoint <= 0) Destroy(gameObject);

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
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) <= modelEnemy.m_Speed) movesEnemy = MovesEnemy.SearchObject;
        else
        {
            if (transform.position.x > Points[index].position.x)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
            if (transform.position.x < Points[index].position.x)
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime);
                transform.eulerAngles = new Vector3(0, 0, 0);
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

    protected override void SearchObject()
    {
        if (Vector3.Distance(transform.position, Player.Instance.transform.position) >= modelEnemy.m_DistanceToThePlayer) movesEnemy = MovesEnemy.DefaultMoves;
        if (transform.position.x > Player.Instance.transform.position.x)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, -180, 0);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
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
