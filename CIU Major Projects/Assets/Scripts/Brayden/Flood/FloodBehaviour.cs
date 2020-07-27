using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodBehaviour : MonoBehaviour
{
    //A reference to our game Object
    public GameObject myFlood;

    public GameObject[] spawnPoints;

    //Death timer references for our Large fire's lifespan.
    public float nextDeath;

    //A reference to our smaller fire.
    public GameObject smallFlood;

    //An array to keep track of how many fire objects are on the screen.
    public GameObject[] listFlood;

    //floats that will be used for spawning our smaller fires over time.
    public float floodSpawnRate;
    public float nextFloodSpawn;

    // Update is called once per frame
    void Update()
    {
        WaterCheck();
        SmallFlood();
        FloodDeath();
    }

    //The large flood will spawn smaller floods over a period of time. Making them travel in 4 different directions
    void SmallFlood()
    {
        if (Time.time > nextFloodSpawn && listFlood.Length <= 9)
        {
            nextFloodSpawn = Time.time + floodSpawnRate;
            //Loop through the spawn points, spawning floods at their positions.
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                Instantiate(smallFlood, spawnPoints[i].transform.position, spawnPoints[i].transform.rotation);
            }
        }
    }

    //Finds our floods within the scene and prints it's length to the console.
    void WaterCheck()
    {
        listFlood = GameObject.FindGameObjectsWithTag("Flood");
        //Debug.Log("There are " + listFlood.Length + " objects");
    }

    void FloodDeath()
    {
        nextDeath = nextDeath + Time.deltaTime;
        //Debug.Log(nextDeath);
        if (nextDeath > 30)
        {
            nextDeath = 0;
            Destroy(myFlood);
        }
    }
}
