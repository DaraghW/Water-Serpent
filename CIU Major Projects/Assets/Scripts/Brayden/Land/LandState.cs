using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandState : MonoBehaviour
{
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
                mySprite.color = Color.green;
                Heal();
                break;
            case HealthState.mediumhealthy:
                mySprite.color = Color.yellow;
                MediumHeal();
                break;
            case HealthState.unhealthy:
                mySprite.color = Color.red;
                BigBoyHeal();
                LandDecay();


                break;
            default:
                Debug.Log("REEEEEEEEEEEEEEE");
                break;
        }
    }

    void Heal()
    {
        //Every x seconds heal for a certain amount.
        if (myHealth < 100)
        {
            myHealth += 0.05f;
        }
    }

    void MediumHeal()
    {
        //Every x seconds heal for a certain amount.
        if (myHealth < 100)
        {
            myHealth += 0.1f;
        }
    }

    void BigBoyHeal()
    {
        //Every x seconds heal for a certain amount.
        if (myHealth < 100)
        {
            myHealth += 0.15f;
        }
    }

    void LandDecay()
    {
        LandHealth.health = LandHealth.health - 0.5f;
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
    }
}
  