using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public float bulletsPerSecond = 1;
    public GameObject bulletPrefab;
    public Transform shootingLocation;

    bool wantsToFire = false;
    float lastFireTime = 0;

    public void OnFire(InputValue value)
    {
        wantsToFire = value.Get<float>() > 0.5f;
    }

    public bool CanFire()
    {
        return Time.time - lastFireTime > 1 / bulletsPerSecond;
    }

    public void Fire()
    {
        lastFireTime = Time.time;
        Instantiate(bulletPrefab, shootingLocation.position, shootingLocation.rotation);
    }

    private void Update()
    {
        if (wantsToFire && CanFire())
        {
            Fire();
        }
    }
}
