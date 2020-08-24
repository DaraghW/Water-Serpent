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
    public Text[] scoreText, nameText;
    public GameObject entryTemplate;
    public Transform entryArea;

    //Our score and name values. As well as our new names & scores.
    public int[] myScores, newScores;
    public string[] myNames, newNames;

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
        //Sorts the score array.
        Array.Sort(myScores);
    }

    //handles how we get our player data for our scores & names.
    void GetPlayerData()
    {

        for (int i = 0; i < newScores.Length; i++)
        {
            newScores[i] = PlayerPrefs.GetInt("newScore" + i.ToString());
        }
        for (int i = 0; i < newNames.Length; i++)
        {
            newNames[i] = PlayerPrefs.GetString("newName" + i.ToString());
        }

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
        for (int i = 0; i < newScores.Length; i++)
        {
            if (newScores[i] > myScores[i])
            {
                //Add new Entry
                myScores[i] = newScores[i];
                myNames[i] = newNames[i];
            }
        } 
    }

    void AddNewEntry()
    { 
        
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
