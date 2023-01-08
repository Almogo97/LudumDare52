using UnityEngine;

public abstract class Flower : MonoBehaviour
{
    public float interactionDistance = 1;
    protected PickUpPrompt pickUp;

    protected Transform player;
    bool promptActive;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pickUp = player.GetComponent<PickUpPrompt>();
        transform.rotation = Quaternion.identity;
    }

    protected virtual void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < interactionDistance)
        {
            if (!promptActive)
            {
                promptActive = true;
                pickUp.Activate(this);
            }
        }
        else if (promptActive)
        {
            promptActive = false;
            pickUp.Deactivate(this);
        }
    }

    public abstract void PickUp();
}
