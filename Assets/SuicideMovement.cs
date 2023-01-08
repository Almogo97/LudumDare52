using UnityEngine;

public class SuicideMovement : MonoBehaviour
{
    public float maxSpeed;
    public float acceleration;
    public float distanceToExplode = 4;
    public float explosionDelay = 1;
    public int damage = 1;

    Transform player;

    new Rigidbody2D rigidbody;
    Animator animator;
    EnemyAim enemyAim;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        enemyAim = GetComponent<EnemyAim>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, player.position) < distanceToExplode)
        {
            animator.SetTrigger("Explode");
            enemyAim.enabled = false;
            rigidbody.velocity = Vector2.zero;
            maxSpeed = 0;
        }
        rigidbody.velocity = Vector2.Lerp(rigidbody.velocity, transform.up * maxSpeed, Time.deltaTime * acceleration);
    }

    public void Explode()
    {
        if (Vector2.Distance(transform.position, player.position) < distanceToExplode)
        {
            player.GetComponent<Health>().Current -= damage;
        }
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, distanceToExplode);
    }
}
