using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    //Our timer, rate we gain score and a reference to the rate Cooldown.
    public float nextScore, scoreRate, time;
    public Slider HPSlider;


    //The time text.
    public Text myTimerText, endText;
    public Text[] myScoreText, endScoretext;

    //Our pause & end of round panels, our players & player panels.
    public GameObject pausePanel, losePanel;
    public GameObject[] myPlayers, myPanels, endScorePanels, endNamePanels;
    public InputField myInputField;

    //The number of players, our scores, our time & scoring rates.
    int players;
    public int[] myScores;
    int t;

    // Start is called before the first frame update
    public void Start()
    {
        GetPlayerPrefs();
        PlayerSwitch(players);
    }

    public void Update()
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
                SetEndScoresActive();
                break;
            case 2:
                SetPlayersActive();
                SetEndScoresActive();
                break;
            case 3:
                SetPlayersActive();
                SetEndScoresActive();
                break;
            case 4:
                SetPlayersActive();
                SetEndScoresActive();
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
        FindObjectOfType<AudioManager>().Play("ButtonBack");
    }

    //Unpauses the game, changing timescale and setting our pause canvas to INactive.
    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        IsPaused = false;
        FindObjectOfType<AudioManager>().Play("ButtonForward");
    }

    //For our pause panel button, if the player chooses to click with the mouse.
    public void ButtonResume()
    {
        myStates = GameState.Unpaused;
        IsPaused = false;
        FindObjectOfType<AudioManager>().Play("ButtonForward");
    }

    public void ButtonPause()
    {
        myStates = GameState.Paused;
        IsPaused = true;
        FindObjectOfType<AudioManager>().Play("ButtonBack");
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

        //A check to make sure our health stays at 0 if it is reached.
        if (LandHealth.health <= 0)
        {
            LandHealth.health = 0;
        }

        //Handles what happens when our health reaches 0.
        if (HPSlider.value <= 0)
        {
            EndOfRound();
            SaveScores();
        }
    }

    //Handles how the game ends, sets the lose UI for each of the players, changes to the lose state.
    void EndOfRound()
    {
        myStates = GameState.Lose;
        Time.timeScale = 0f;
        losePanel.SetActive(true);
        endText.text = "You lasted a total of " + time.ToString() + " seconds";

        for (int i = 0; i < myScores.Length; i++)
        {
            endScoretext[i].text = myScores[i].ToString();
        }
    }

    //Sets our end score panels active (name and scores)
    void SetEndScoresActive()
    {
        for (int i = 0; i < players; i++)
        {
            endScorePanels[i].SetActive(true);
        }
        endNamePanels[0].SetActive(true);
    }

    //Changes a bunch of the UI for the timer, score & health. Changes the value for our health slider.
    void UpdateUI()
    {
        for (int i = 0; i < myScoreText.Length; i++)
        {
            myScoreText[i].text = myScores[i].ToString();
        }
        myTimerText.text = time.ToString("F0");

        HPSlider.value = LandHealth.health;
    }

    //Saves our scores to an integer and appends it to a list.
    void SaveScores()
    {
        for (int i = 0; i < myScores.Length; i++)
        {
            //take the current scores and assign them to the new scores array.
            //Set the player prefs for the new scores.
            t += myScores[i];
            PlayerPrefs.SetInt("newScore", t);
        }
        PlayerPrefs.Save();
    }

    public void SetName()
    {
        string newName = myInputField.text;
        PlayerPrefs.SetString("newName", newName);
        Debug.Log("Saving " + newName);
        PlayerPrefs.Save();
    }

    public void ShowMyPanel(GameObject panel)
    {
        panel.SetActive(true);
    }
}
