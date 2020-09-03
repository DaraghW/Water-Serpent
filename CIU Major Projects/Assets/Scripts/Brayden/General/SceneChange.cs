using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public Animator[] transition;
    public float transTime;
    public void CoopScene(int playerAmount)
    {
        //Saves our playerAmount int to whatever amount is chosen to player prefs.
        //Loads the co op scene.
        FindObjectOfType<AudioManager>().Play("ButtonForward");
        PlayerPrefs.SetInt("players", playerAmount);
        Debug.Log(playerAmount);
        SceneManager.LoadScene("Co-OpScene");
    }

    public void VsScene()
    {
        FindObjectOfType<AudioManager>().Play("ButtonForward");
        SceneManager.LoadScene("VS-Scene");
    }

    public void MainMenu()
    {
        FindObjectOfType<AudioManager>().Play("ButtonBack");
        SceneManager.LoadScene("MainMenu");
    }

    public void HighScores()
    {
        FindObjectOfType<AudioManager>().Play("ButtonForward");
        SceneManager.LoadScene("HighScores");
    }

    //Quits the game.
    public void GameQuit()
    {
        Application.Quit();
    }

    //Sets our score to zero. This is so that when players load from the main menu scene, new scores will not be added.
    public void SetScoreNull()
    {
        PlayerPrefs.SetInt("newScore", 0);
        PlayerPrefs.SetString("newName", "");
    }

    //Resets the preferences, used as a test for the HS table.
    public void ResettiPrefetti()
    {
        PlayerPrefs.DeleteAll();
    }

    //Saves our player prefs.
    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }

    public void LoadNextLevel(int i)
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + i));
    }

    IEnumerator LoadLevel(int i)
    {
        //Play our animation.
        for (int e = 0; e <= transition.Length; e++)
        {
            transition[e].SetTrigger("Start");
        }

        //Wait
        yield return new WaitForSeconds(transTime);

        //LoadScene
        SceneManager.LoadScene(i);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            MainMenu();
        }
    }
}
