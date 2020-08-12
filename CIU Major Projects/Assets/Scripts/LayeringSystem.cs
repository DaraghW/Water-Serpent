using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeringSystem : MonoBehaviour
{
    public SpriteRenderer parentGameObject;
    public float checkRate = 0.5f, nextCheck = 0.25f;
    public SpriteRenderer myRenderer;
    public bool isStatic;

    private void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
        InvokeRepeating("CheckLayer", checkRate, nextCheck);
    }

    void CheckLayer()
    {
        if (parentGameObject)
        {
            myRenderer.sortingOrder = parentGameObject.sortingOrder - 1;
            return;
        }

        /*check the y position every x times per seconds. 
            *Takes the y float value at 1 decimal place, cuts the decimal off.
            *Times by 10.
            *Assign new number to layer value. */

        myRenderer.sortingOrder = Mathf.RoundToInt(transform.position.y * -10);
        if (isStatic)
            CancelInvoke();
    }
}
