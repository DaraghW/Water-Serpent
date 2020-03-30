using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DecayScript : MonoBehaviour
{
    public float health;
    public float healthyDecay;
    public float mediumDecay;
    public float unhealthyDecay;
    public float time;
    public float fireThreshold;
    public float unhealthyThreshold;

    public Text timerText;
    public Slider healthSlider;
    public Text loseText;

    public float fireRate;
    public float nextFire;

    public GameObject[] fireSpawns;
    public GameObject myFire;

    // Update is called once per frame
    void Update()
    {
        SpawnFire();
        GameHandle();
        UpdateUI();
    }

    void SpawnFire()
    {
        int i = Random.Range(0, fireSpawns.Length);

        //Spawn fire at random spawn points if the threshold is reached.
        if (health <= fireThreshold && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(myFire, fireSpawns[i].transform.position, fireSpawns[i].transform.rotation);
        }
    }

    void GameHandle()
    {
        time = time + Time.deltaTime;

        if (health > fireThreshold)
        {
            health = health - healthyDecay;
        }
        else if (health > unhealthyThreshold)
        {
            health = health - mediumDecay;
        }
        else 
        {
            health = health - unhealthyDecay;
        }

        if (health <= 0)
        {
            loseText.text = "YOU LOSE".ToString();
        }
    }

    void UpdateUI()
    {
        timerText.text = "Time: " + time.ToString();
        healthSlider.value = health;
    }
}
  