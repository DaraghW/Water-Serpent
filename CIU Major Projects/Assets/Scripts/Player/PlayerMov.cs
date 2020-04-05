using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed;
    public float turnDelay;
    private bool canTurn;

    public float maxTailLength;
    public float maxWaterLength;
    public float timer;
    public float maxTimer;

    public Transform tailStart;
    public GameObject tailPart;
    public GameObject water;

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

        
        //MAKE TAIL PARTS
        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(tailPart, tailStart.position, Quaternion.identity);

            Instantiate(water, tailStart.position, Quaternion.identity);
            timer = maxTimer;
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
            maxTailLength += 1;
        }
    }
}
