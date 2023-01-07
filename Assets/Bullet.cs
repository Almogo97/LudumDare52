using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float secondsToLive = 1f;
    public float speed = 1f;
    public int damage = 1;

    private void Start()
    {
        Destroy(gameObject, secondsToLive);
    }

    private void Update()
    {
        transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Health health = collision.GetComponent<Health>();
        if (health != null)
        {
            health.Current -= damage;
        }
        Destroy(gameObject);
    }
}
