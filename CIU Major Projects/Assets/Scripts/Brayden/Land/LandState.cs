using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandState : MonoBehaviour
{
    public Color healthyColor;
    public Color medHealthyColor;
    public Color unHealthyColor;

    public float decayRate, decayAmount, nextDecay, nextHeal, healRate;
    public float fireDecayRate, fireDecayAmount, nextFireDecay;
    public float waterDecayRate, waterDecayAmount, nextWaterDecay;

    public GameObject myController;

    //An enumerator for our health states.
    public enum HealthState
    { 
        healthy,
        mediumhealthy,
        unhealthy
    }

    //A reference to our health states.
    public HealthState healthStates;

    //Our ground's sprite renderer.
    public SpriteRenderer mySprite;

    //Health thresholds & max health.
    public float myHealth;
    public float healthyThreshold;
    public float unhealthyThreshold;

    void Start()
    {
        //Sets our health state to healthy.
        healthStates = HealthState.healthy;
    }

    // Update is called once per frame
    void Update()
    {
        HealthCheck();
        HealthyState();
    }

    //Handles how our land looks at different health states.
    void HealthyState()
    {
        switch (healthStates)
        {
            case HealthState.healthy:
                break;
            case HealthState.mediumhealthy:
                mySprite.color = medHealthyColor;
                MediumHeal();
                break;
            case HealthState.unhealthy:
                mySprite.color = unHealthyColor;
                BigBoyHeal();
                LandDecay();
                break;
            default:
                Debug.Log("REEEEEEEEEEEEEEE");
                break;
        }
    }

    //Handles how our ground decays when a hazard is on it.
    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Fire" && Time.time > nextFireDecay)
        {
            Debug.Log("Fired");
            nextFireDecay = Time.time + fireDecayRate;
            myHealth -= fireDecayAmount;
        }

        if (collider.gameObject.tag == "Flood" && Time.time > nextWaterDecay)
        {
            nextWaterDecay = Time.time + waterDecayRate;
            myHealth -= waterDecayAmount;
        }
    }


    void MediumHeal()
    {
        //Every x seconds heal for a certain amount.
        if (myHealth < 100 && Time.time > nextHeal)
        {
            nextHeal = Time.time + healRate;
            myHealth += 0.1f;
        }
    }

    void BigBoyHeal()
    {
        //Every x seconds heal for a certain amount.
        if (myHealth < 100 && Time.time > nextHeal)
        {
            nextHeal = Time.time + healRate;
            myHealth += 0.15f;
        }
    }

    void LandDecay()
    {
        if(Time.time > nextDecay)
        {
            nextDecay = Time.time + decayRate;
            LandHealth.health = LandHealth.health - decayAmount;
        }   
    }

    //Handles the health states of the land.
    void HealthCheck()
    {
        if (myHealth > healthyThreshold)
        {
            healthStates = HealthState.healthy;
        }
        else if (myHealth <= healthyThreshold && myHealth >= unhealthyThreshold)
        {
            healthStates = HealthState.mediumhealthy;
        }
        else if (myHealth > 0)
        {
            healthStates = HealthState.unhealthy;
        }

        if (myHealth <= 0)
        {
            myHealth = 0;
        }
    }
}
  