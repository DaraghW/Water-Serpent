using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableMovement : MonoBehaviour
{
    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Vector2 moveSpots;
    public int xPos;
    public int yPos;
    private Vector2 velocity;
    public float maxSpeed = 2;

    Animator anim;

    void Start()
    {
        MakeRandomPosition();

        anim = GetComponent<Animator>();

    }

    void Update()
    {
        Move();
        //Flip();
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
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);

    }
    /*
    private void Flip()
    {

    }
    */
}
