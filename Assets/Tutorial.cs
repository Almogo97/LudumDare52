using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
