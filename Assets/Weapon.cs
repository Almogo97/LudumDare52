using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float bulletsPerSecond = 1;
    public GameObject bulletPrefab;
    public Transform shootingLocation;
    public int AddedDmg = 0;

    float lastFireTime;

    public bool CanFire()
    {
        return Time.time - lastFireTime > 1 / bulletsPerSecond;
    }

    public void Fire()
    {
        lastFireTime = Time.time;
        var instance = Instantiate(bulletPrefab, shootingLocation.position, shootingLocation.rotation);
        Bullet bullet = instance.GetComponent<Bullet>();
        if (bullet != null)
        {
            bullet.damage += AddedDmg;
        }
        instance.layer = gameObject.layer;
    }
}
