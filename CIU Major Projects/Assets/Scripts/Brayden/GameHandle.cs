using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandle : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject myGround;
    public GameObject[] myFire;
    public DecayScript myDecay;

    public bool IsPaused = false;

    public enum GameState
    { 
        Unpaused,
        Paused
    }

    public GameState myStates;

    void Start()
    {
        myDecay = myGround.GetComponentInChildren<DecayScript>();
        myStates = GameState.Unpaused;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == false)
        {
            myStates = GameState.Paused;
            IsPaused = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && IsPaused == true)
        {
            myStates = GameState.Unpaused;
            IsPaused = false;
        }

        switch (myStates)
        {
            case GameState.Paused:
                Pause();
                break;
            case GameState.Unpaused:
                Resume();
                break;
            default:
                break;
        }
        FireCheck();
    }

    void FireCheck()
    {
        myFire = GameObject.FindGameObjectsWithTag("Fire");
        Debug.Log("There are " + myFire.Length + " objects");
    }
    void FirePause()
    {
        for (int i = myFire.Length - 1; i >= 0; i--)
        {
            myFire[i].SetActive(false);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        myDecay.gameObject.SetActive(false);
        FirePause();
        IsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        myDecay.gameObject.SetActive(true);
        IsPaused = false;
    }

    public void ButtonResume()
    {
        myStates = GameState.Unpaused;
        IsPaused = false;
    }
}
