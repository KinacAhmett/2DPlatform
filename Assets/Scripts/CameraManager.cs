using UnityEngine;

public class CameraManager : MonoBehaviour
{

public Transform target;
public float cameraSpeed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Slerp(transform.position, new Vector3(target.position.x, target.position.y, transform.position.z), cameraSpeed);
    }
}
