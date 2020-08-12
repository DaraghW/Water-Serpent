﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player4Mov : MonoBehaviour
{
    public float moveSpeed;
    public float regSpeed;
    public float turnDelay;
    private bool canTurn;

    public float maxTailLength;
    public float maxWaterLength;
    public float timer;
    public float maxTimer;

    float rTime;
    float tTime;

    public Rigidbody2D rb;
    public Transform tailStart;

    public GameObject water;

    // Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite headR;
    public Sprite headL;
    public Sprite headD;
    public Sprite headU;

    //tail part
    public GameObject currentTail;
    public GameObject sideTail;
    public GameObject topTail;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, 0);
        currentTail = sideTail;
    }

    // Update is called once per frame
    void Update()
    {
        //controlls
        turnDelay -= 1 * Time.deltaTime;
        if (turnDelay <= 0)
        {
            canTurn = true;
        }
        //UP
        if (Input.GetKeyDown(KeyCode.UpArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKeyDown(KeyCode.LeftArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKeyDown(KeyCode.DownArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKeyDown(KeyCode.RightArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }


        //MAKE TAIL PARTS
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(currentTail, tailStart.position, Quaternion.identity);

            Instantiate(water, tailStart.position, Quaternion.identity);
            timer = maxTimer;
        }

        //Rat 
        rTime -= 1 * Time.deltaTime;
        if (rTime >= 0)
        {
            moveSpeed = 5;

        }
        if (rTime <= 0)
        {
            moveSpeed = regSpeed;
        }

        tTime -= 1 * Time.deltaTime;
        if (tTime >= 0)
        {
            maxWaterLength += 5;
        }

        if (GameObject.FindGameObjectsWithTag("Tail").Length >= maxTailLength)
        {
            Destroy(GameObject.FindWithTag("Tail"));
        }
        if (GameObject.FindGameObjectsWithTag("Water").Length >= maxWaterLength)
        {
            Destroy(GameObject.FindWithTag("Water"));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tail")
        {
            //Fail();
            //Debug.Log("oof");
        }

        if (collision.gameObject.tag == "Egg")
        {
            Grow();
            print("egg eaten");
        }
        if (collision.gameObject.tag == "Insect")
        {
            Grow();
            Insect();
            print("bug eaten");
        }
        if (collision.gameObject.tag == "Rat")
        {
            Grow();
            maxWaterLength += 3;
            print("rat eaten");
        }
    }

    void Grow()
    {
        maxTailLength += 1;
        maxWaterLength += 1;
    }
    void Insect()
    {
        rTime = 3;
    }

    void Fail()
    {
        moveSpeed = 0;
        maxTailLength = 3;
        maxWaterLength = 8;
    }
}
