using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFire : MonoBehaviour
{
    //A reference to our game object.
    public GameObject myGameObject;
    public GameObject largeFire;

    //The amount of health that will be taken from the land by the fire at certain intervals.
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
            scorekeeper.myScores[0] = scorekeeper.myScores[0] + 100;
        }

        if (collision.gameObject.tag == "Player2")
        {
            myGameObject.SetActive(false);
            scorekeeper.myScores[1] = scorekeeper.myScores[1] + 100;
        }

        if (collision.gameObject.tag == "Player3")
        {
            myGameObject.SetActive(false);
            scorekeeper.myScores[2] = scorekeeper.myScores[2] + 100;
        }

        if (collision.gameObject.tag == "Player4")
        {
            myGameObject.SetActive(false);
            scorekeeper.myScores[3] = scorekeeper.myScores[3] + 100;
        }

        if (collision.gameObject.tag == "Flood")
        {
            Destroy(myGameObject);
        }
    }
}
