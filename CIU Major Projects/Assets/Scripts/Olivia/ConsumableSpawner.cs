using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableSpawner : MonoBehaviour
{
    //public GameObject egg;
    public int xPos;
    public int yPos;
    public int consumableCount;
    public GameObject[] consumables;
    //public GameObject insect;
    //public GameObject rat;
    int randconsumable;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ConsumableDrop());
    }

    IEnumerator ConsumableDrop()
    {
        while(consumableCount < 5)
        {
            randconsumable = Random.Range(0, 3);
            xPos = Random.Range(-29, 29);
            yPos = Random.Range(-29, 29);
            Instantiate(consumables[randconsumable], new Vector3(xPos, yPos, 0), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            consumableCount ++;
        }
    }
}
