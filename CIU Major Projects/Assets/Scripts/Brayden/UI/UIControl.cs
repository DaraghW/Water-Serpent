using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    int i = 0;

    public Button[] myButtons;

    private void Start()
    {
        SetSelection();
    }

    private void Update()
    {
        //ChangeButtonInt();
    }

    void SetSelection()
    {
        i = 0;
        myButtons[i].Select();
    }
    void ChangeButtonInt()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            i += 1;
            myButtons[i].Select();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            i -= 1;
            myButtons[i].Select();
        }
    }
}
