using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public Vector2 speed = new Vector2(10, 10);
    public Vector2 direction = new Vector2(-1, 0);

    private Vector2 movement;

    private void Update()
    {
        movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
    }

    
}
