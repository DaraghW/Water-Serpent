using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    public GameObject myGround;
    public DecayScript decay;
    public Rigidbody2D myRb;
    public GameObject myFire;
    public int i;

    public float fireRate;
    public float nextFire;

    public float decayRate;
    public float decayAmount;
    public float nextDecay;

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
        decay = myGround.GetComponentInChildren<DecayScript>();
    }

    void Update()
    {
        Decay();
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
        //Debug.Log(i);

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

    void Decay()
    {
        if (decay.myHealth > 0 && Time.time > nextDecay)
        {
            nextDecay = Time.time + decayRate;
            decay.myHealth -= decayAmount;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myFire.SetActive(false);
            LandHealth.health = LandHealth.health + 500;
            ScoreKeeper.score = ScoreKeeper.score + 100;
            
            if (decay.myHealth <= 200)
            {
                decay.myHealth = decay.myHealth + 10;
            }
        }
    }
}
