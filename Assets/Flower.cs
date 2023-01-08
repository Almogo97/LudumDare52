using UnityEngine;

public abstract class Flower : MonoBehaviour
{
    public float interactionDistance = 1;
    protected PickUpPrompt pickUp;

    Transform player;
    bool promptActive;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pickUp = player.GetComponent<PickUpPrompt>();
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < interactionDistance)
        {
            promptActive = true;
            pickUp.Activate(this);
        }
        else if (promptActive)
        {
            promptActive = false;
            pickUp.Deactivate(this);
        }
    }

    public abstract void PickUp();
}
