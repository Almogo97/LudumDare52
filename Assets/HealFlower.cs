using UnityEngine;

public class HealFlower : Flower
{
    public int stage = 1;
    public float toStage2 = 30;
    public float toStage3 = 60;

    float startTime;

    private void Start()
    {
        startTime = Time.time;
    }

    public override void PickUp()
    {
        player.GetComponent<Health>().Current += stage;
        Destroy(gameObject);
    }

    protected override void Update()
    {
        base.Update();
        if (stage < 3 && Time.time - startTime >= toStage3)
        {
            stage = 3;
            transform.localScale *= 1.5f;
        }
        else if (stage < 2 && Time.time - startTime >= toStage2)
        {
            stage = 2;
            transform.localScale *= 1.5f;
        }
    }
}
