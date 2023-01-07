using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float acceleration = 1;
    public float deceleration = 1;
    public float maxSpeed = 10f;

    public new Rigidbody2D rigidbody;
    public Vector2 inputDirection;

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
        //rigidbody.MovePosition(rigidbody.position + speed * Time.deltaTime * inputDirection);
        if (inputDirection == Vector2.zero)
        {
            rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, Vector2.zero, Time.deltaTime * deceleration);
        }
        rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, inputDirection * maxSpeed, Time.deltaTime * acceleration);
    }
}
