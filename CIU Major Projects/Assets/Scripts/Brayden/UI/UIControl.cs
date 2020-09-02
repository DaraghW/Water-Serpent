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

    void SetSelection()
    {
        i = 0;
        myButtons[i].Select();
    }
}

// Remember to chan ge line 265 to not specify max players = 1!
