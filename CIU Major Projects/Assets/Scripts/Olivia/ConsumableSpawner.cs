using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSpawner : MonoBehaviour
{
    public int xPos;
    public int yPos;
    public int consumableCount;
    public GameObject[] consumables;
    public int randconsumable;
    
    void Start()
    {
        StartCoroutine(ConsumableDrop());
    }

    IEnumerator ConsumableDrop()
    {
        while(consumableCount <= 4)
        {
            randconsumable = Random.Range(0, 2);
            xPos = Random.Range(-29, 29);
            yPos = Random.Range(-29, 29);
            Instantiate(consumables[randconsumable], new Vector3(xPos, yPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            consumableCount ++;
        }
    }
}
