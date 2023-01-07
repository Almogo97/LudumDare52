using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 1;

    new Rigidbody2D rigidbody;
    Vector2 inputDirection;

    public void OnMove(InputValue value)
    {
        Vector2 direction = value.Get<Vector2>();
        inputDirection = direction;

    }

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime * inputDirection);
    }
}
