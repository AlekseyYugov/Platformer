using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Camera main_camera;

    private float positionX;
    private void Start()
    {
        positionX = player.position.x;
    }
    private void Update()
    {
        //if (positionX < player.position.x)
        //{
            
        //    positionX = player.position.x;
        //}
        main_camera.transform.position = new Vector3(player.transform.position.x + 5f, main_camera.transform.position.y, main_camera.transform.position.z);

    }
}
