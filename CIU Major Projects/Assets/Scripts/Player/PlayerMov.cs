using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed;
    public float turnDelay;
    private bool canTurn;

    public int maxLength;
    private bool canMakeTail;
    public float timer;
    public float maxTimer;

    public Transform tailStart;
    public GameObject tailPart;
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //constant move        
        transform.position += transform.right * moveSpeed * Time.deltaTime;

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
        if (Input.GetKeyDown(KeyCode.W) && transform.rotation != Quaternion.Euler(0, 0, -90) && canTurn == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
            canTurn = false;
            turnDelay = .1f;
        }

        if (Input.GetKeyDown(KeyCode.A) && transform.rotation != Quaternion.Euler(0, 0, 0) && canTurn == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            canTurn = false;
            turnDelay = .1f;
        }

        if (Input.GetKeyDown(KeyCode.S) && transform.rotation != Quaternion.Euler(0, 0, 90) && canTurn == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
            canTurn = false;
            turnDelay = .1f;
        }

        if (Input.GetKeyDown(KeyCode.D) && transform.rotation != Quaternion.Euler(0, 0, 180) && canTurn == true)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            canTurn = false;
            turnDelay = .1f;
        }

        
        
        timer -= 1 * Time.deltaTime;
        if (GameObject.FindGameObjectsWithTag("Tail").Length >= maxLength)
        {
            canMakeTail = true;
            //Debug.Log("make tail");
        }

        if (timer <= 0 && canMakeTail == true)
        {
            Instantiate(tailPart, tailStart.position, Quaternion.identity);
            timer = maxTimer;
            Debug.Log(GameObject.FindGameObjectsWithTag("Tail").Length);
        }

        //if (GameObject.FindGameObjectsWithTag("Tail").Length <= maxLength && timer <= 0)
        //{
        //    Instantiate(tailPart, tailStart.position, Quaternion.identity);
        //    timer = maxTimer;
        //    Debug.Log(GameObject.FindGameObjectsWithTag("Tail").Length);
        //}

        Debug.Log(GameObject.FindGameObjectsWithTag("Tail").Length); 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tail")
        {
            Debug.Log("oof");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Cockroach")
        {
            maxLength += 1;
        }
    }
}
