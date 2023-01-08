using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;

    void Update()
    {
        Vector3 desiredPosition = target.position;
        desiredPosition.z = transform.position.z;
        transform.position = desiredPosition;
    }

}