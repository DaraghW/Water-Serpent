using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreRoundScript : MonoBehaviour
{
    public float countDown = 5;
    public Text countText;
    public GameObject[] myPanels, myPlayers;

    public Movement[] myMovement;


    void CountDown()
    {
        countDown = countDown - Time.deltaTime;
        if (countDown <= 3)
        {
            countText.text = (countDown).ToString("F0");
        }
        
        if (countDown <= 0)
        {
            countText.text = "GO!".ToString();
            SetFalsePanel();
            StartPlayers();
        }

        if (countDown <= -2)
        {
            countText.text = " ".ToString();
        }
    }

    private void Start()
    {
        StopPlayers();
        SetTruePanel();
    }

    private void Update()
    {
        CountDown();
    }

    void StopPlayers()
    {
        for (int i = 0; i < myPlayers.Length; i++)
        {
            myMovement[i] = myPlayers[i].GetComponent<Movement>();
            myMovement[i].enabled = false;
        }
    }

    void StartPlayers()
    {
        for (int i = 0; i < myPlayers.Length; i++)
        {
            myMovement[i] = myPlayers[i].GetComponent<Movement>();
            myMovement[i].enabled = true;
        }
    }

    void SetFalsePanel()
    {
        myPanels[0].SetActive(false);
    }

    void SetTruePanel()
    {
        myPanels[0].SetActive(true);
    }
}
