using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int max = 2;
    public UnityEvent<int> OnHealthChange;
    public UnityEvent OnDeath;

    private int current;

    public int Current
    {
        get => current;
        set
        {
            current = Mathf.Clamp(value, 0, max);
            OnHealthChange.Invoke(current);
            if (current <= 0)
            {
                OnDeath.Invoke();
            }
        }
    }

    private void Start()
    {
        Current = max;
    }
}
