using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    //A reference to our large fire game object.
    public GameObject largeFire;
    public GameObject[] spawnPoints;

    //floats that will be used for spawning our smaller fires over time.
    public float fireSpawnRate;
    public float nextFireSpawn;

    void Update()
    {
        FireSpawn();
    }
    
    //Will spawn a large fire periodically.
    void FireSpawn()
    {
        if (Time.time > nextFireSpawn)
        {
            nextFireSpawn = Time.time + fireSpawnRate;
            Instantiate(largeFire, spawnPoints[Random.Range(0, 8)].transform.position, transform.rotation);
        }
    }
}
