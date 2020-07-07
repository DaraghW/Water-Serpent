using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameHandle : MonoBehaviour
{
    //A reference to our land health.
    public LandHealth landHealth;

    //Our pause & end of round panels.
    public GameObject pausePanel;
    public GameObject losePanel;

    //The time.
    public float time;

    //Our health, timer, score & lose texts.
    public Text landHealthText;
    public Text timerText;
    public Text scoreText;
    public Text loseText;
    
    //Our health slider.
    public Slider landHealthSlider;

    //A pause boolean to keep track of the pause states.
    public bool IsPaused = false;

    //An enum for our game states.
    public enum GameState
    { 
        Unpaused,
        Paused,
        Lose
    }

    //A reference to our game states.
    public GameState myStates;

    void Start()
    {
        //Starts the game with zero score, grabs the landhealthcomponent from the script and makes our game state to unpaused.
        ScoreKeeper.score = 0;
        landHealth = GetComponent<LandHealth>();
        myStates = GameState.Unpaused;
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

    //Changes a bunch of the UI for the timer, score & health. Changes the value for our health slider.
    void UpdateUI()
    {
        timerText.text = "Time: " + time.ToString();
        scoreText.text = "Score " + ScoreKeeper.score.ToString();
        landHealthSlider.value = LandHealth.health;
        landHealthText.text = "Health " + ((LandHealth.health/LandHealth.maxHealth) * 100)  + "%".ToString();
    }

    void GameHandler()
    {
        //Changes our time to be relative to delta time.
        time = time + Time.deltaTime;
        
        //Increases our score.
        ScoreKeeper.score = ScoreKeeper.score + 1;

        //Handles what happens when our health reaches 0.
        if (landHealthSlider.value <= 0)
        {
            myStates = GameState.Lose;
            Time.timeScale = 0f;
            losePanel.SetActive(true);
            loseText.text = "You lasted a total of " + time.ToString() + " seconds & scored a total of " + ScoreKeeper.score.ToString() + " points!";
        }

        //A check to make sure our health stays at 0 if it is reached.
        if (LandHealth.health <= 0)
        {
            LandHealth.health = 0;
        }
    }
}
