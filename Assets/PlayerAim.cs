using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public new Camera camera;

    Vector3 mouseWorldPosition;

    public void OnLook(InputValue value)
    {
        Vector2 mouseScreenPosition = value.Get<Vector2>();
        mouseWorldPosition = camera.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;
    }

    private void Update()
    {
        transform.up = mouseWorldPosition - transform.position;
    }
}
