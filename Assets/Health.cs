using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int max = 2;
    public UnityEvent<int> OnHealthChange;
    public UnityEvent<int> OnMaxHealthChange;
    public UnityEvent OnDeath;

    private int current;

    public int Current
    {
        get => current;
        set
        {
            current = Mathf.Clamp(value, 0, Max);
            OnHealthChange.Invoke(current);
            if (current <= 0)
            {
                OnDeath.Invoke();
            }
        }
    }

    public int Max
    {
        get => max;
        set
        {
            max = value;
            OnMaxHealthChange.Invoke(max);
        }
    }

    private void Start()
    {
        OnMaxHealthChange.Invoke(Max);
        Current = Max;
    }
}
