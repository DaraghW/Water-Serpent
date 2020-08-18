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
            FindObjectOfType<AudioManager>().Play("PanelOpen");
        }
        else if (isOpen == true)
        {
            isOpen = false;
            gameObject.SetActive(false);
            FindObjectOfType<AudioManager>().Play("ButtonBack");
        }
    }

    public void CloseThePanel(GameObject gameObject)
    {
        gameObject.SetActive(false);
        FindObjectOfType<AudioManager>().Play("ButtonBack");
    }
}
