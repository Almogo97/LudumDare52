using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    Weapon weapon;
    bool wantsToFire = false;

    public void OnFire(InputValue value)
    {
        wantsToFire = value.Get<float>() > 0.5f;
    }

    private void Awake()
    {
        weapon = GetComponent<Weapon>();
    }


    private void Update()
    {
        if (wantsToFire && weapon.CanFire())
        {
            weapon.Fire();
        }
    }
}
