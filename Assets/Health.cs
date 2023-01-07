using UnityEngine;

public class Health : MonoBehaviour
{
    public int max = 2;

    private int current;

    public int Current
    {
        get => current;
        set
        {
            current = Mathf.Clamp(value, 0, max);

            if (current <= 0)
            {
                Kill();
            }
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        Current = max;
    }
}
