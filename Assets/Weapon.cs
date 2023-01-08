using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float bulletsPerSecond = 1;
    public GameObject bulletPrefab;
    public Transform shootingLocation;

    float lastFireTime;

    public bool CanFire()
    {
        return Time.time - lastFireTime > 1 / bulletsPerSecond;
    }

    public void Fire()
    {
        lastFireTime = Time.time;
        var instance = Instantiate(bulletPrefab, shootingLocation.position, shootingLocation.rotation);
        instance.layer = gameObject.layer;
    }
}
