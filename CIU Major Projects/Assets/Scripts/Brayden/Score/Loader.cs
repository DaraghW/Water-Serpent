using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;

public class Loader : MonoBehaviour
{
    //Our text box that refrence our scores and names.
    public Text[] scoreText;
    public Text[] nameText;

    //Our score and name values.
    public int[] myScores;
    public string[] myNames;

    //Our new score and name references.
    public int newScore;
    public string newName;

    //Calls our functions that get, set, sort & display the data as well as append new data.
    void Start()
    {
        GetPlayerData();
        SortData();
        SetNewScore();
        SortData();
        SetData();;
        SetUI();
        SavePrefs();
    }

    //Sorts our list of scores in order.
    void SortData()
    {
        Array.Sort(myScores);
        for (int i = 0; i < myNames.Length && myNames.Length > 2; i++)
        {
            for (int j = i + 0; j < myNames.Length; j++)
            {
                if (myNames[i].Length < myNames[j].Length)
                {
                    string tempString = myNames[i];
                    myNames[i] = myNames[j];
                    myNames[j] = tempString;
                }
            }
        }
    }

    //handles how we get our player data for our scores & names.
    void GetPlayerData()
    {
        newScore = PlayerPrefs.GetInt("newScore");
        newName = PlayerPrefs.GetString("newName");

        for (int j = 0; j < myScores.Length; j++)
        {
            myScores[j] = PlayerPrefs.GetInt("h" + j.ToString());
        }

        for (int j = 0; j < myScores.Length; j++)
        {
            myNames[j] = PlayerPrefs.GetString("n" + j.ToString());
        }
    }

    void SetNewScore()
    {
        //If the new highscore is larger than the lowest score, delete the old score and add the new score + name.
        if (newScore > myScores[0])
        {
            myScores[0] = newScore;
            myNames[0] = newName;
        }
    }

    //Loops through our code for each data entry in our score & name arrays. Sets our player prefs for each.
    void SetData()
    {
        for (int j = 0; j < myScores.Length; j++)
        {
            PlayerPrefs.SetInt("h" + j.ToString(), myScores[j]);
        }

        for (int j = 0; j < myScores.Length; j++)
        {
            PlayerPrefs.SetString("n" + j.ToString(), myNames[j]);
        }
    }

    //Sets the UI for our positions text.
    void SetUI()
    {
        for (int i = 0; i < myScores.Length; i++)
        {
            nameText[i].text = myNames[i].ToString();
        }

        for (int i = 0; i < myScores.Length; i++)
        {
            scoreText[i].text = myScores[i].ToString();
        }
    }

    //Saves our player prefs.
    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
