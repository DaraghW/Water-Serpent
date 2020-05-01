using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandle : MonoBehaviour
{
    public LandHealth landHealth;
    public GameObject pausePanel;
    public GameObject[] myFire;

    public float time;

    public Text landHealthText;
    public Text timerText;
    public Text scoreText;
    public Text loseText;
    public Slider landHealthSlider;

    public bool IsPaused = false;

    public enum GameState
    { 
        Unpaused,
        Paused
    }

    public GameState myStates;

    void Start()
    {
        ScoreKeeper.score = 0;
        landHealth = GetComponent<LandHealth>();
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
                GameHandler();
                UpdateUI();
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

    public void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        IsPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        IsPaused = false;
    }

    public void ButtonResume()
    {
        myStates = GameState.Unpaused;
        IsPaused = false;
    }

    void UpdateUI()
    {
        timerText.text = "Time: " + time.ToString();
        scoreText.text = "Score " + ScoreKeeper.score.ToString();
        landHealthSlider.value = LandHealth.health;
        landHealthText.text = LandHealth.health.ToString();
    }

    void GameHandler()
    {
        time = time + Time.deltaTime;
        ScoreKeeper.score = ScoreKeeper.score + 1;

        if (landHealthSlider.value <= 0)
        {
            loseText.text = "YOU LOSE".ToString();
            Invoke("LoadMenu", 2f);
        }

        if (LandHealth.health <= 0)
        {
            LandHealth.health = 0;
        }
    }

    void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
