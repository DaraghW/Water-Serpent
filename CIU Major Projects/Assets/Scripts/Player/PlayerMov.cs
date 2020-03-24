using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMov : MonoBehaviour
{
    public float moveSpeed;

    //public float length;
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

        if (Input.GetKeyDown(KeyCode.W) && transform.rotation != Quaternion.Euler(0, 0, -90))
        {
            transform.rotation = Quaternion.Euler(0, 0, 90);
        }

        if (Input.GetKeyDown(KeyCode.A) && transform.rotation != Quaternion.Euler(0, 0, 0))
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
            //RotateLeft();
        }

        if (Input.GetKeyDown(KeyCode.S) && transform.rotation != Quaternion.Euler(0, 0, 90))
        {
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }

        if (Input.GetKeyDown(KeyCode.D) && transform.rotation != Quaternion.Euler(0, 0, 180))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //RotateRight();
        }

        timer -= 1 * Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(tailPart, tailStart.position,Quaternion.identity);
            timer = maxTimer;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Tail")
        {
            Destroy(gameObject);
        }
    }
}
