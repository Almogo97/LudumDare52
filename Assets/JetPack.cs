using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class JetPack : MonoBehaviour
{
    public float speedMultiplier = 1.2f;
    public float speedBurst = 3f;
    public float secondsHolding = 0.4f;
    public float energyRecoverRate = 1f;
    public float burstEnergyCost = 50;
    public float sustainedEnergyCostPerSecond = 20f;
    public Slider slider;
    PlayerMovement movement;
    public ParticleSystem sustainedParticleSystem;
    public ParticleSystem burstParticleSystem;
    public Animator jetPackSliderAnimator;

    bool isHolding;
    float holdTimer;
    float oldSpeed;
    float newSpeed;
    private float currentEnergy;

    public float CurrentEnergy
    {
        get => currentEnergy;
        set
        {
            currentEnergy = Mathf.Clamp(value, 0, 100);
            slider.value = currentEnergy;
        }
    }

    private void Awake()
    {
        movement = GetComponent<PlayerMovement>();
        currentEnergy = 100;
    }

    private void Update()
    {
        if (isHolding && Time.time - holdTimer > secondsHolding)
        {
            CurrentEnergy -= sustainedEnergyCostPerSecond * Time.deltaTime;
            if (CurrentEnergy > 0)
            {
                movement.maxSpeed = newSpeed;
                if (!sustainedParticleSystem.isPlaying)
                {
                    sustainedParticleSystem.Play();
                }
            }
            else
            {
                movement.maxSpeed = oldSpeed;
                sustainedParticleSystem.Stop();
            }
        }

        CurrentEnergy += Time.deltaTime * energyRecoverRate;
    }

    public void OnJetPack(InputValue value)
    {
        isHolding = value.Get<float>() > 0.5f;
        if (isHolding)
        {
            oldSpeed = movement.maxSpeed;
            newSpeed = movement.maxSpeed * speedMultiplier;
            holdTimer = Time.time;
        }
        else
        {
            movement.maxSpeed = oldSpeed;
            sustainedParticleSystem.Stop();
        }
    }

    public void OnJetPackFast(InputValue value)
    {
        if (CurrentEnergy > burstEnergyCost)
        {
            CurrentEnergy -= burstEnergyCost;
            movement.rigidbody.AddForce(movement.inputDirection * speedBurst, ForceMode2D.Impulse);
            burstParticleSystem.Play();
        }
        else
        {
            jetPackSliderAnimator.SetTrigger("Empty");
        }
    }
}
