using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFlood : MonoBehaviour
{
    //A reference to our game object.
    public GameObject myGameObject;
    public GameObject largeFlood;

    //The amount of health that will be taken from the land by the water at certain intervals.
    public float decayRate;
    public float decayAmount;
    public float nextDecay;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            myGameObject.SetActive(false);
            LandHealth.health = LandHealth.health + 10;
            ScoreKeeper.score = ScoreKeeper.score + 50;
        }

        if (collision.gameObject.tag == "Flood")
        {
            Destroy(myGameObject);
            //Instantiate(largeFlood, transform.position, transform.rotation);
        }

        if (collision.gameObject.tag == "Fire")
        {
            Destroy(myGameObject);
        }
    }

    //Handles how our ground decays when this hazard is on it.
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground" && Time.time > nextDecay)
        {
            Debug.Log("Grounded");
            nextDecay = Time.time + decayRate;
            collision.gameObject.GetComponentInChildren<LandState>().myHealth -= decayAmount;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
