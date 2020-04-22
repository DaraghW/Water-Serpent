using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Daragh
public class PlayerMov : MonoBehaviour
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
    public GameObject tailPart;
    public GameObject water;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(moveSpeed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //constant move        
        //rb.velocity = new Vector2(moveSpeed, 0);

        /*
        for looking at mouse
        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        */

        //WASD controlls
        turnDelay -= 1 * Time.deltaTime;
        if (turnDelay <= 0)
        {
            canTurn = true;
        }
        //UP
        if (Input.GetKeyDown(KeyCode.W) && transform.rotation != Quaternion.Euler(0, 0, -90) && canTurn == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            rb.velocity = new Vector2(0,moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Left
        if (Input.GetKeyDown(KeyCode.A) && transform.rotation != Quaternion.Euler(0, 0, 0) && canTurn == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            rb.velocity = new Vector2(-moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }
        //Down
        if (Input.GetKeyDown(KeyCode.S) && transform.rotation != Quaternion.Euler(0, 0, 90) && canTurn == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            rb.velocity = new Vector2(0,-moveSpeed);
            canTurn = false;
            turnDelay = .2f;
        }
        //Right
        if (Input.GetKeyDown(KeyCode.D) && transform.rotation != Quaternion.Euler(0, 0, -180) && canTurn == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rb.velocity = new Vector2(moveSpeed, 0);
            canTurn = false;
            turnDelay = .2f;
        }

        
        //MAKE TAIL PARTS
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(tailPart, tailStart.position, Quaternion.identity);

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
        if(collision.gameObject.tag == "Tail")
        {
            //Fail();
            //Debug.Log("oof");
        }

        if(collision.gameObject.tag == "Cockroach")
        {
            Grow();
        }
        if (collision.gameObject.tag == "Rat")
        {
            Grow();
            Rat();
        }
        if (collision.gameObject.tag == "Toad")
        {
            Grow();
            maxWaterLength += 3;
        }
    }

    void Grow()
    {
        maxTailLength += 1;
        maxWaterLength += 1;
    }
    void Rat()
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
