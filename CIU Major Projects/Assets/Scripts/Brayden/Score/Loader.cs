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
    public int newScore;
    public string newName;


    //Our name and score lists.
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
        //Get the new score and name.
        newScore = PlayerPrefs.GetInt("newScore");
        newName = PlayerPrefs.GetString("newName");

        for (int i = 0; i <= scoreNames.Count - 1; i++)
        {
            scoreNames[i] = PlayerPrefs.GetString("oldNames" + i.ToString());
            highScores[i] = PlayerPrefs.GetInt("oldScores" + i.ToString());
        }
    }

    void AddNewEntry()
    {
        for (int i = 0; i < highScores.Count; i++)
        {
            //Checks the elements of the list. If the new element is above a certain value it removes the old one from the list.
            if (newScore > highScores[i])
            {
                highScores.Insert(i, newScore);
                scoreNames.Insert(i, newName);
                PlayerPrefs.SetString("oldNames" + i.ToString(), newName);
                PlayerPrefs.SetInt("oldScores" + i.ToString(), newScore);
                return;
            }
            newScore = 0;
            PlayerPrefs.SetInt("newScore", newScore);
        }
    }

    //Sets the UI for our positions text.
    void SetUI()
    {
        //From 1 - 10, set the text for the name and score to the list values.
        for (int i = 0; i <= scoreText.Length; i++)
        {
            scoreText[i].text = highScores[i].ToString();
            nameText[i].text = scoreNames[i].ToString();
        }
    }

    //Saves our player prefs.
    public void SavePrefs()
    {
        PlayerPrefs.Save();
    }
}
