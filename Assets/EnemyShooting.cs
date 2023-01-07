using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    private Weapon weapon;

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        if (weapon.CanFire())
        {
            weapon.Fire();
        }
    }
}
