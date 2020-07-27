using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStayInside : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBounds")
        {
            transform.position = collision.transform.position;
        }
    }
}
