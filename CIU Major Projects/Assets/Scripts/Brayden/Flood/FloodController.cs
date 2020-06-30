using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloodController : MonoBehaviour
{
    //A reference to our large flood game object.
    public GameObject largeFlood;

    public GameObject[] spawnPoints;

    //floats that will be used for spawning our smaller fires over time.
    public float floodSpawnRate;
    public float nextFloodSpawn;

    void Update()
    {
        FloodSpawn();
    }

    //Will spawn a large floods periodically.
    void FloodSpawn()
    {
        if (Time.time > nextFloodSpawn)
        {
            nextFloodSpawn = Time.time + floodSpawnRate;
            Instantiate(largeFlood, spawnPoints[Random.Range(0, 8)].transform.position, transform.rotation);
        }
    }
}
