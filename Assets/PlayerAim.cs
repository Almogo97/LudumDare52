using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAim : MonoBehaviour
{
    public new Camera camera;

    Vector2 mouseScreenPosition;

    public void OnLook(InputValue value)
    {
        mouseScreenPosition = value.Get<Vector2>();
    }

    private void Update()
    {
        Vector3 mouseWorldPosition = camera.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;
        transform.up = mouseWorldPosition - transform.position;
    }
}
