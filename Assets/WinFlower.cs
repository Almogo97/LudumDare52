using TMPro;
using UnityEngine;

public class WinFlower : Flower
{
    public override void PickUp()
    {
        pickUp.winScreen.SetActive(true);
        pickUp.prompt.GetComponent<TextMeshProUGUI>().enabled = false;
        Time.timeScale = 0;
    }
}
