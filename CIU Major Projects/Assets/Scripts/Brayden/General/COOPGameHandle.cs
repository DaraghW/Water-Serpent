using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class COOPGameHandle : MonoBehaviour
{
    //An enum for our game states.
    public enum GameState
    {
        Unpaused,
        Paused,
        Lose
    }

    //A reference to our game states.
    public GameState myStates;

    //A pause boolean to keep track of the pause states.
    public bool IsPaused = false;

    int players;

    //The time.
    public float time;
    public Text myTimerText;

    //Our pause & end of round panels.
    public GameObject pausePanel, losePanel;

    //Areference to our gameObjects and players.
    public GameObject[] myPlayers;
    public GameObject[] myPanels;

    public int[] myScores;
    public float nextScore;
    public float scoreRate; 
    public Text[] myScoreText;


    // Start is called before the first frame update
    void Start()
    {
        GetPlayerPrefs();
        PlayerSwitch(players);
    }

    void Update()
    {
        //If Escape is pressed, then change the game state depending if the game is already paused or not.
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

        //Our switch for our game states.
        switch (myStates)
        {
            case GameState.Lose:
                Debug.Log("I've lost");
                break;
            case GameState.Paused:
                Pause();
                break;
            case GameState.Unpaused:
                Resume();
                GameHandler();
                UpdateUI();
                break;
            default:
                break;
        }
    }

    void GetPlayerPrefs()
    {
        players = PlayerPrefs.GetInt("players");
    }

    void SetPlayersActive()
    {
        for (int i = 0; i < players; i++)
        {
            myPlayers[i].SetActive(true);
            myPanels[i].SetActive(true);
        }
    }

    void PlayerSwitch(int players)
    {
        switch (players)
        {
            case 1:
                SetPlayersActive();
                break;
            case 2:
                SetPlayersActive();
                break;
            case 3:
                SetPlayersActive();
                break;
            case 4:
                SetPlayersActive();
                break;
            default:
                break;
        }
    }

    //Pauses the game, changing timescale and setting our pause canvas to ACTIVE.
    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        IsPaused = true;
    }

    //Unpauses the game, changing timescale and setting our pause canvas to INactive.
    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        IsPaused = false;
    }

    //For our pause panel button, if the player chooses to click with the mouse.
    public void ButtonResume()
    {
        myStates = GameState.Unpaused;
        IsPaused = false;
    }

    public void ButtonPause()
    {
        myStates = GameState.Paused;
        IsPaused = true;
    }

    void GameHandler()
    {
        //Changes our time to be relative to delta time.
        time = time + Time.deltaTime;

        //Increases our scores.
        if (Time.time > nextScore)
        {
            nextScore = Time.time + scoreRate;
            for (int i = 0; i < myScores.Length; i++)
            {
                myScores[i] += 1;
            }
        }
    }

    //Changes a bunch of the UI for the timer, score & health. Changes the value for our health slider.
    void UpdateUI()
    {
        for (int i = 0; i < myScoreText.Length; i++)
        {
            myScoreText[i].text = myScores[i].ToString();
        }
        myTimerText.text = time.ToString("F0");
    }
}
