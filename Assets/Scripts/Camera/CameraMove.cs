using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Camera main_camera;
    [SerializeField] private AudioSource audioSource;
    private void Start()
    {
        audioSource.Play();
    }
    private void Update()
    {
        main_camera.transform.position = new Vector3(player.transform.position.x + 5f, main_camera.transform.position.y, main_camera.transform.position.z);

    }
}
