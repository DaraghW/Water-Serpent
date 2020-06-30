using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void MultiGame()
    {
        SceneManager.LoadScene("MultiplayerScene");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HighScores()
    {
        SceneManager.LoadScene("HighScores");
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
