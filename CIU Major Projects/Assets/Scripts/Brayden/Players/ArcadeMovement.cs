using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeMovement : MonoBehaviour
{
    public float moveSpeed, regSpeed, turnDelay, maxTailLength,
        maxWaterLength, timer, maxTimer, rTime, tTime;
    
    private bool canTurn;

    public Rigidbody2D rb;
    public Transform tailStart;

    public GameObject water, myObject;

    // Sprites
    public SpriteRenderer spriteRenderer;
    public Sprite headR, headL, headD,headU;

    //tail part
    public GameObject currentTail, sideTail, topTail;

    //Consumables
    public ConsumableSpawner consumableSpawnerScript;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
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

        if (myObject.tag == "Player1")
        {
            Player1Move();
        }

        if (myObject.tag == "Player2")
        {
            Player2Move();
        }

        if (myObject.tag == "Player3")
        {
            Player3Move();
        }

        if (myObject.tag == "Player4")
        {
            Player4Move();
        }

        //MAKE TAIL PARTS
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            MakeTail();
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

    public bool p1xAxis;
    void Player1Move()
    {
        //x mov
        if (p1xAxis == true)
        {
            //Input.GetAxis(Joystick)
        }

        //y mov


        ////UP
        //if (Input.GetKey(KeyCode.W) && canTurn == true)
        //{
        //    //transform.rotation = Quaternion.Euler(0, 0, 90);
        //    spriteRenderer.sprite = headU;
        //    currentTail = topTail;
        //    rb.velocity = new Vector2(0, moveSpeed);
        //    canTurn = false;
        //    turnDelay = .2f;
        //}
        ////Left
        //if (Input.GetKey(KeyCode.A) && canTurn == true)
        //{
        //    //transform.rotation = Quaternion.Euler(0, 0, 180);
        //    spriteRenderer.sprite = headL;
        //    currentTail = sideTail;
        //    rb.velocity = new Vector2(-moveSpeed, 0);
        //    canTurn = false;
        //    turnDelay = .2f;
        //}
        ////Down
        //if (Input.GetKey(KeyCode.S) && canTurn == true)
        //{
        //    //transform.rotation = Quaternion.Euler(0, 0, -90);
        //    spriteRenderer.sprite = headD;
        //    currentTail = topTail;
        //    rb.velocity = new Vector2(0, -moveSpeed);
        //    canTurn = false;
        //    turnDelay = .2f;
        //}
        ////Right
        //if (Input.GetKey(KeyCode.D) && canTurn == true)
        //{
        //    //transform.rotation = Quaternion.Euler(0, 0, 0);
        //    spriteRenderer.sprite = headR;
        //    currentTail = sideTail;
        //    rb.velocity = new Vector2(moveSpeed, 0);
        //    canTurn = false;
        //    turnDelay = .2f;
        //}
    }

    void Player2Move()
    {
        //UP
        if (Input.GetKey(KeyCode.T) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKey(KeyCode.F) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKey(KeyCode.G) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKey(KeyCode.H) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
    }

    void Player3Move()
    {
        //UP
        if (Input.GetKey(KeyCode.I) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKey(KeyCode.J) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKey(KeyCode.K) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKey(KeyCode.L) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
    }

    void Player4Move()
    {
        //UP
        if (Input.GetKey(KeyCode.UpArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 90);
            spriteRenderer.sprite = headU;
            currentTail = topTail;
            rb.velocity = new Vector2(0, moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKey(KeyCode.LeftArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 180);
            spriteRenderer.sprite = headL;
            currentTail = sideTail;
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKey(KeyCode.DownArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, -90);
            spriteRenderer.sprite = headD;
            currentTail = topTail;
            rb.velocity = new Vector2(0, -moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKey(KeyCode.RightArrow) && canTurn == true)
        {
            //transform.rotation = Quaternion.Euler(0, 0, 0);
            spriteRenderer.sprite = headR;
            currentTail = sideTail;
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
    }

    void MakeTail()
    {
        Instantiate(currentTail, tailStart.position, Quaternion.identity);
        //tail.GetComponent<LayeringSystem>().parentGameObject = GetComponent<SpriteRenderer>();
        Instantiate(water, tailStart.position, Quaternion.identity);
        //myWater.GetComponent<LayeringSystem>().parentGameObject = tail.GetComponent<SpriteRenderer>();
        timer = maxTimer;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Egg")
        {
            Grow();
            print("egg eaten");
            Destroy(collision.gameObject);
            consumableSpawnerScript.consumableCurrentCount--;
        }
        
        if (collision.gameObject.tag == "Insect")
        {
            Destroy(collision.gameObject);
            Grow();
            Insect();
            consumableSpawnerScript.consumableCurrentCount--;
        }
        
        if (collision.gameObject.tag == "Rat")
        {
            Destroy(collision.gameObject);
            Grow();
            Rat();
            consumableSpawnerScript.consumableCurrentCount--;
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
        print("bug eaten");
    }

    void Rat()
    {
        maxWaterLength += 3;
        print("rat eaten");
    }
}
