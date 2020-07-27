using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBehaviour : MonoBehaviour
{
    //Death timer references for our Large fire's lifespan.
    public float nextDeath;

    //A reference to our smaller fire.
    public GameObject smallFire;

    //An array to keep track of how many fire objects are on the screen.
    public GameObject[] listFire;

    //floats that will be used for spawning our smaller fires over time.
    public float fireSpawnRate;
    public float nextFireSpawn;

    //A reference to our rigidbody and our game object.
    public Rigidbody2D myRb;
    public GameObject myFire;

    //floats that will be used for moving our larger fire around over time.
    public float moveRate;
    public float nextMove;

    //A vector 2 that will be used to move our fire around.
    private Vector2 RandomVector(int min, int max)
    {
        int x = Random.Range(min, max);
        int y = Random.Range(min, max);
        return new Vector2(x, y);
    }

    void Update()
    {
        FireCheck();
        SmallFire();
        MoveAround();
        FireDeath();
    }

    //Handles how our fire moves.
    void MoveAround()
    {
        //Clamp the fire to be within the constraints of the game world.
        //Move the fire in random directions.
        if (Time.time > nextMove)
        {
            nextMove = Time.time + moveRate;
            myRb.velocity = RandomVector(Random.Range(-5, 5), Random.Range(-5, 5));
        }
    }

    //The large fire will spawn smaller fires over a period of time.
    void SmallFire()
    {
        if (Time.time > nextFireSpawn && listFire.Length <= 9)
        {
            nextFireSpawn = Time.time + fireSpawnRate;
            Instantiate(smallFire, transform.position, transform.rotation);
        }
    }

    //Finds our fire within the scene and prints it's length to the console.
    void FireCheck()
    {
        listFire = GameObject.FindGameObjectsWithTag("Fire");
        //Debug.Log("There are " + listFire.Length + " objects");
    }
    void FireDeath()
    {
        nextDeath = nextDeath + Time.deltaTime;
        //Debug.Log(nextDeath);
        if (nextDeath > 30)
        {
            nextDeath = 0;
            Destroy(myFire);
        }
    }

}
