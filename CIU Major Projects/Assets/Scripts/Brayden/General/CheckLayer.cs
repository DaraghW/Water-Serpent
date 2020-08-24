using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLayer : MonoBehaviour
{
    public SpriteRenderer myObject;
    // Start is called before the first frame update

    void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player1")
        {
            myObject.sortingOrder = collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }

        if (collider.gameObject.tag == "Player2")
        {
            myObject.sortingOrder = collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }

        if (collider.gameObject.tag == "Player3")
        {
            myObject.sortingOrder = collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }

        if (collider.gameObject.tag == "Player4")
        {
            myObject.sortingOrder = collider.gameObject.GetComponent<SpriteRenderer>().sortingOrder - 1;
        }
    }
}
