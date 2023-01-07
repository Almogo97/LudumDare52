using UnityEngine;

public class EnemyAim : MonoBehaviour
{
    public float speed = 1;
    public Transform target;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 targetDirection = target.position - transform.position;
        targetDirection.Normalize();
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90;
        Quaternion desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, desiredRotation, speed * Time.deltaTime);
    }
}
