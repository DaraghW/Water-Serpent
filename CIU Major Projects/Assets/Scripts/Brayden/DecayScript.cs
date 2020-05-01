using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecayScript : MonoBehaviour
{
    public enum HealthState
    { 
        healthy,
        mediumhealthy,
        unhealthy
    }

    public HealthState healthStates;

    public SpriteRenderer mySprite;

    public float myHealth = 100;
    public float fireThreshold = 80;
    public float healthyThreshold;
    public float unhealthyThreshold = 40;
    public float healthyDecay;
    public float mediumDecay;
    public float unhealthyDecay;

    public int landDecay;

    public GameObject[] myFire;

    public float fireRate;
    public float nextFire;

    void Start()
    {
        healthStates = HealthState.healthy;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnFire();
        HealthCheck();
        Decay();
    }

    //Handles how the fire spawns in the scene.
    void SpawnFire()
    {
        int i = Random.Range(0, myFire.Length - 1);

        //Spawn fire at random spawn point if the firethreshold is reached.
        if (myHealth <= fireThreshold && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            myFire[i].SetActive(true);
        }
    }

    //Handles the decay rate at different health states of the land.
    void Decay()
    {
        switch (healthStates)
        {
            case HealthState.healthy:
                myHealth = myHealth - healthyDecay;
                mySprite.color = Color.green;
                break;
            case HealthState.mediumhealthy:
                myHealth = myHealth - mediumDecay;
                mySprite.color = Color.yellow;
                break;
            case HealthState.unhealthy:
                myHealth = myHealth - unhealthyDecay;
                mySprite.color = Color.red;
                LandDecay();
                break;
            default:
                Debug.Log("REEEEEEEEEEEEEEE");
                break;
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
        else if(myHealth > 0)
        {
            healthStates = HealthState.unhealthy;
        }
    }

    void LandDecay()
    {
        LandHealth.health = LandHealth.health - landDecay;
    }
}
  