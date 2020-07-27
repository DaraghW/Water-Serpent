using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class Loader : MonoBehaviour
{
    //Our text boxes that refrence our scores and names.
    public Text[] scoreText;
    public Text[] nameText;

    //Our score and name values.
    public int[] myScores;
    public string[] myNames;

    public int newScore;
    public string newName;
    // Start is called before the first frame update
    void Start()
    {
        GetPlayerData();
        SortData();
        SetNewScore();
        SortData();
        SetPlayerData();
        SetUI();
    }

    //Sorts our list of scores in order.
    public void SortData()
    {
        Array.Sort(myScores);
        Array.Sort(myNames);

        for (int i = 0; i < myScores.Length; i++)
        {
            print(myScores[i]);
        }
    }

    void GetPlayerData()
    {
        newScore = PlayerPrefs.GetInt("newScore");
        newName = PlayerPrefs.GetString("newName");

        myScores[0] = PlayerPrefs.GetInt("highscore1");
        myScores[1] = PlayerPrefs.GetInt("highscore2");
        myScores[2] = PlayerPrefs.GetInt("highscore3");
        myScores[3] = PlayerPrefs.GetInt("highscore4");
        myScores[4] = PlayerPrefs.GetInt("highscore5");
        myScores[5] = PlayerPrefs.GetInt("highscore6");
        myScores[6] = PlayerPrefs.GetInt("highscore7");
        myScores[7] = PlayerPrefs.GetInt("highscore8");
        myScores[8] = PlayerPrefs.GetInt("highscore9");
        myScores[9] = PlayerPrefs.GetInt("highscore10");

        myNames[0] = PlayerPrefs.GetString("name1");
        myNames[1] = PlayerPrefs.GetString("name2");
        myNames[2] = PlayerPrefs.GetString("name3");
        myNames[3] = PlayerPrefs.GetString("name4");
        myNames[4] = PlayerPrefs.GetString("name5");
        myNames[5] = PlayerPrefs.GetString("name6"); 
        myNames[6] = PlayerPrefs.GetString("name7");
        myNames[7]= PlayerPrefs.GetString("name8");
        myNames[8]= PlayerPrefs.GetString("name9");
        myNames[9]= PlayerPrefs.GetString("name10");
    }

    void SetNewScore()
    {
        //If the new highscore is larger than the lowest score, delete the old score and add the new score.
        if (newScore > myScores[0])
        {
            myScores[0] = newScore;
            myNames[0] = newName;
        }
    }

    void SetPlayerData()
    {
        PlayerPrefs.SetInt("highscore1", myScores[0]);
        PlayerPrefs.SetInt("highscore2", myScores[1]);
        PlayerPrefs.SetInt("highscore3", myScores[2]);
        PlayerPrefs.SetInt("highscore4", myScores[3]);
        PlayerPrefs.SetInt("highscore5", myScores[4]);
        PlayerPrefs.SetInt("highscore6", myScores[5]);
        PlayerPrefs.SetInt("highscore7", myScores[6]);
        PlayerPrefs.SetInt("highscore8", myScores[7]);
        PlayerPrefs.SetInt("highscore9", myScores[8]);
        PlayerPrefs.SetInt("highscore10", myScores[9]);

        PlayerPrefs.SetString("name1", myNames[0]);
        PlayerPrefs.SetString("name2", myNames[1]);
        PlayerPrefs.SetString("name3", myNames[2]);
        PlayerPrefs.SetString("name4", myNames[3]);
        PlayerPrefs.SetString("name5", myNames[4]);
        PlayerPrefs.SetString("name6", myNames[5]);
        PlayerPrefs.SetString("name7", myNames[6]);
        PlayerPrefs.SetString("name8", myNames[7]);
        PlayerPrefs.SetString("name9", myNames[8]);
        PlayerPrefs.SetString("name10", myNames[9]);
    }

    void SetUI()
    {
        for (int i = 0; i < myScores.Length; i++)
        {
            scoreText[i].text = myScores[i].ToString();
        }

        for (int i = 0; i < myNames.Length; i++)
        {
            nameText[i].text = myNames[i];
        }
    }

    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }

    //Resets the opreferences, used as a test for the HS table.
    public void ResettiPrefetti()
    {
        PlayerPrefs.DeleteAll();
    }
}
