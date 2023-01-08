using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public Transform healthPanel;
    public GameObject heartPrefab;

    public void ChangeMaxHealth(int value)
    {
        for (int i = healthPanel.childCount; i < value; i++)
        {
            Instantiate(heartPrefab, healthPanel);
        }
    }

    public void ChangeCurrentHealth(int value)
    {
        int i = 0;
        foreach (Transform heart in healthPanel)
        {
            heart.GetComponent<SpriteRenderer>().color = i < value ? Color.red : Color.white;
            i++;
        }
    }
}
