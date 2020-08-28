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

    public List<int>highScores = new List<int>();
    public List<string> scoreNames = new List<string>();

    //Calls our functions that get, set, sort & display the data as well as append new data.
    void Start()
    {
        GetPlayerData();
        AddNewEntry();
        SetUI();
        SavePrefs();
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
    }

    void AddNewEntry()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            //Checks the elements of the list. If the new element is above a certain value it removes the old one from the list.
            if (newScores[i] > highScores[i])
            {
                highScores.Insert(i, newScores[i]);
                scoreNames.Insert(i, newNames[i]);
                break;
            }
        }
    }

    //Sets the UI for our positions text.
    void SetUI()
    {
        for (int i = 0; i < myScores.Length; i++)
        {
            nameText[i].text = scoreNames[i].ToString();
        }

        for (int i = 0; i < myScores.Length; i++)
        {
            scoreText[i].text = highScores[i].ToString();
        }
    }

    //Saves our player prefs.
    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
