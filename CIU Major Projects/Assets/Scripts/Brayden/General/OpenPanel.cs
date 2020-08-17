using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanel : MonoBehaviour
{
    public bool isOpen;

    private void Start()
    {
        isOpen = false;
    }

    public void OpenThePanel(GameObject gameObject)
    {
        if (isOpen == false)
        {
            isOpen = true;
            gameObject.SetActive(true);
        }
        else if (isOpen == true)
        {
            isOpen = false;
            gameObject.SetActive(false);
        }
    }

    public void CloseThePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}
