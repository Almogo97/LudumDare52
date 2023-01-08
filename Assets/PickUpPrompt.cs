using System.Collections.Generic;
using UnityEngine;

public class PickUpPrompt : MonoBehaviour
{
    public GameObject prompt;
    public GameObject winScreen;

    List<Flower> flowerList = new List<Flower>();

    public void Activate(Flower flower)
    {
        flowerList.Add(flower);
        ShowPrompt();
    }

    public void ShowPrompt()
    {
        prompt.SetActive(flowerList.Count > 0);
    }

    public void Deactivate(Flower flower)
    {
        flowerList.Remove(flower);
        ShowPrompt();
    }

    public void OnInteract()
    {
        if (flowerList.Count > 0)
        {
            flowerList[0].PickUp();
            Deactivate(flowerList[0]);
        }
    }
}
