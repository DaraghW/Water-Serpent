using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TailPart : MonoBehaviour
{
    public float upTimer;

    //Update is called once per frame
    void Update()
    {
        upTimer -= 1 * Time.deltaTime;
        if (upTimer <= 0)
        {
            Destroy(gameObject);
        }
    }
}
