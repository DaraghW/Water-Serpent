using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHP : MonoBehaviour
{
    public float health;
    public float decayRate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health -= decayRate * Time.deltaTime;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            health += decayRate * 2 * Time.deltaTime;
            print("splash");
        }        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {

    }
}
