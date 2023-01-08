using System;
using TMPro;
using UnityEngine;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    public float seconds = 3;
    public GameObject winFlowerPrefab;

    bool gameWon = false;

    private void Start()
    {
        Print();
    }

    void Print()
    {
        var t = TimeSpan.FromSeconds(seconds);
        textMeshProUGUI.text = string.Format("{0:D2}:{1:D2}:{2:D2}",
                t.Minutes,
                t.Seconds,
                t.Milliseconds);
    }

    private void Update()
    {
        if (gameWon) { return; }
        if (seconds > 0)
        {
            seconds -= Time.deltaTime;
            Print();
        }
        else
        {
            textMeshProUGUI.text = "00:00:00";
            Instantiate(winFlowerPrefab, Vector3.zero, Quaternion.identity);
            gameWon = true;
        }
    }
}
