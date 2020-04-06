using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public DecayScript decay;
    public float decayRate;
    public Rigidbody2D myRb;
    public GameObject myFire;
    public int i;

    public float fireRate;
    public float nextFire;
    public int firePercentile;

    public float moveRate;
    public float nextMove;

    private Vector2 RandomVector(int min, int max)
    {
        int x = Random.Range(min, max);
        int y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    void Start()
    {
        decay = FindObjectOfType<DecayScript>();
    }

    void Update()
    {
        decay.health -= decayRate;
        FireSpawning();
        MoveAround();
    }


    //Handles how our fire moves.
    void MoveAround()
    {
        //Clamp the fire to be within the constraints of the game world.
        //Move the fire in random directions.
            myRb.velocity = RandomVector(Random.Range(-5, 5), Random.Range(-5, 5));
    }

    //Give the fire a random chance of spreading depending on how unhealthy the land is.
    void FireSpawning()
    {
        CalculateSpawnChance();
        Debug.Log(i);

        if(i >= 100 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(myFire, transform.position, transform.rotation);
        }
    }

    void CalculateSpawnChance()
    {
        i = Random.Range(0, firePercentile);
    }


}
