using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSpawner : MonoBehaviour
{
    public int consumableMaxCount, consumableCurrentCount, randConsumable, xPos, yPos;
    public GameObject[] consumables;
    
    void Start()
    {
        consumableCurrentCount = 0;
        InvokeRepeating("ConsumableDrop", 0.1f, 0.25f);
    }

    void ConsumableDrop()
    {
        if(consumableCurrentCount <= consumableMaxCount)
        {
            randConsumable = Random.Range(0, 3);
            xPos = Random.Range(-14, 14);
            yPos = Random.Range(-14, 14);
            Instantiate(consumables[randConsumable], new Vector3(xPos, yPos, 0), Quaternion.identity);
            consumableCurrentCount++;
        }
    }
}
