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

    GameObject myController;
    COOPGameHandle scorekeeper;
    private void Start()
    {
        myController = GameObject.FindGameObjectWithTag("MultiplayerGameController");
        scorekeeper = myController.GetComponentInChildren<COOPGameHandle>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {
            myGameObject.SetActive(false);
            scorekeeper.myScores[0] = scorekeeper.myScores[0] + 500;
        }
        
        if (collision.gameObject.tag == "Player2")
        {
            myGameObject.SetActive(false);
            scorekeeper.myScores[1] = scorekeeper.myScores[1] + 500;
        }

        if (collision.gameObject.tag == "Player3")
        {
            myGameObject.SetActive(false);
            scorekeeper.myScores[2] = scorekeeper.myScores[2] + 500;
        }

        if (collision.gameObject.tag == "Player4")
        {
            myGameObject.SetActive(false);
            scorekeeper.myScores[3] = scorekeeper.myScores[3] + 500;
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
            //Debug.Log("Grounded");
            nextDecay = Time.time + decayRate;
            collision.gameObject.GetComponentInChildren<LandState>().myHealth -= decayAmount;
        }
    }

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
