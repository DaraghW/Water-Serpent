using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallFlood : MonoBehaviour
{
    //A reference to our game object.
    public GameObject myGameObject;
    public GameObject largeFlood;

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

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime);
    }
}
