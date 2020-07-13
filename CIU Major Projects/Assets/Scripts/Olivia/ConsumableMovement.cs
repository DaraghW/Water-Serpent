using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableMovement : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Vector2 moveSpots;
    private int randomSpot;
    public int xPos;
    public int yPos;
    private Vector2 velocity;
    public float maxSpeed = 2;

    void Start()
    {
        MakeRandomPosition();
    }

    void Update()
    {
        Move();
        LookAt();
    }

    private void MakeRandomPosition()
    {
        xPos = Random.Range(-29, 29);
        yPos = Random.Range(-29, 29);

        moveSpots = new Vector2(xPos, yPos);
        waitTime = startWaitTime;
    }

    private void Move()
    {
        transform.position = Vector2.SmoothDamp(transform.position, moveSpots, ref velocity, speed, maxSpeed);

        if (Vector2.Distance(transform.position, moveSpots) < 0.2f)
        {
            if (waitTime <= 0)
            {
                MakeRandomPosition();
                //randomSpot = Random.Range(0, moveSpots.Length);
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void LookAt()
    {
        //snap its direction towards what its looking at
    }
    /*
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length);
        waitTime = startWaitTime;

    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
    */
}
