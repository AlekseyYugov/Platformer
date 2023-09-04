using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorPosition : MonoBehaviour
{
    [SerializeField] private Transform cursor;
    [SerializeField] private new Camera camera;

    public static GameObject triggerObject;

    private void Update()
    {
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        Plane plane = new Plane(-Vector3.forward, Vector3.zero);

        float distanse;
        plane.Raycast(ray, out distanse);
        Vector3 point = ray.GetPoint(distanse);

        cursor.position = point;
        Cursor.visible = false;



    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        triggerObject = collision.gameObject;

        if (collision.name == "GroundCheck") triggerObject = collision.GetComponentInParent<Rigidbody2D>().gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triggerObject = null;
    }
}
