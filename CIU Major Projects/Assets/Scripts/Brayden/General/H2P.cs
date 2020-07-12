using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class H2P : MonoBehaviour
{
    public bool isOpen;
    public GameObject myPanel;

    private void Start()
    {
        myPanel.SetActive(false);
        isOpen = false;
    }

    public void OpenMenu()
    {
        if (isOpen == false)
        {
            isOpen = true;
            myPanel.SetActive(true);
        }
        else if (isOpen == true)
        {
            isOpen = false;
            myPanel.SetActive(false);
        }
    }
}
