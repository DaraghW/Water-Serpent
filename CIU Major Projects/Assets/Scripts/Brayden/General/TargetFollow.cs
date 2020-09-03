using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TargetFollow : MonoBehaviour
{
    int players;
    public float speed, maxDistance;
    public Transform[] targets;
    // Start is called before the first frame update
    void Start()
    {
        GetPlayers();
    }

    // Update is called once per frame
    void Update()
    {
        TrackTargets();
    }

    void GetPlayers()
    {
        players = PlayerPrefs.GetInt("players");
    }

    void TrackTargets()
    {
        for (int i = 0; i < players - 1; i++)
        {
            if (Vector2.Distance(transform.position, targets[i].position) > maxDistance && targets[i].gameObject.activeInHierarchy == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, targets[i].position, speed * Time.deltaTime);
            }
        }
    }
}
