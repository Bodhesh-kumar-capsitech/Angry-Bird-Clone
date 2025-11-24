using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f;
    Vector3 smoothedPosition;
    public Vector3 offset; 
    public Vector3 originalPosition;
    public static CameraController instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        originalPosition = transform.position;
        
    }
    void LateUpdate()
    {
        if (target != null)
        {
        if(target.position.x > transform.position.x)
        {
            Vector3 desiredPosition = target.position + offset;
            smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        }
    }

    public void ResetCamera()
    {
    transform.position = originalPosition;
    }

}