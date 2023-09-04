using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RaiseObject : MonoBehaviour
{
    [SerializeField] private float Mass;
    [SerializeField] private float Drag;
    public LayerMask Ground;
    public bool onGround;
    public bool onAbove;
    public Transform groundCheck;
    public Transform aboveCheck;
    public float checkRadius = 0.5f;

    private void Start()
    {
        onGround = false;
    }
    private void Update()
    {
        CheckingGround();
        if (onGround == false)
        {
            gameObject.GetComponent<Rigidbody2D>().mass = 1;
            gameObject.GetComponent<Rigidbody2D>().drag = 1;
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().mass = Mass;
            gameObject.GetComponent<Rigidbody2D>().drag = Drag;
        }
    }

    private void CheckingGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, Ground);
        onAbove = Physics2D.OverlapCircle(aboveCheck.position, checkRadius, Ground);
    }
}
