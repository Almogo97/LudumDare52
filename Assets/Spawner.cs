using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float minSpawnsPerSecond = 0.5f;
    public float maxSpawnsPerSecond = 2;
    public float spawnInnerCircle = 5;
    public float spawnOuterCircle = 8;

    public GameObject prefab;
    private Transform player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(Spawn());
    }

    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2);
        while (true)
        {
            Vector3 spawnPosition = Random.insideUnitCircle * Random.Range(spawnInnerCircle, spawnOuterCircle);
            float angle = Mathf.Atan2(-spawnPosition.y, -spawnPosition.x) * Mathf.Rad2Deg - 90;
            Quaternion desiredRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            Instantiate(prefab, spawnPosition, desiredRotation);
            yield return new WaitForSeconds(Random.Range(1 / minSpawnsPerSecond, 1 / maxSpawnsPerSecond));
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, spawnInnerCircle);
        Gizmos.DrawWireSphere(transform.position, spawnOuterCircle);
    }
}
