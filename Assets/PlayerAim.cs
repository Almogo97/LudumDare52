using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public new Camera camera;

    public void OnLook(InputValue value)
    {
        Vector2 mouseScreenPosition = value.Get<Vector2>();
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(mouseScreenPosition);
        //Vector3 targetDirection = mouseWorldPosition - transform.position;
        //float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        mouseWorldPosition.z = 0;
        transform.up = mouseWorldPosition - transform.position;
    }
}
