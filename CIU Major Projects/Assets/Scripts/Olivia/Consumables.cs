using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumables : MonoBehaviour
{
    private CharacterController charcontroller;
    
    // Start is called before the first frame update
    void Start()
    {
        charcontroller = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Cockroach"))
        {
            Debug.Log("IT HIT");
            Destroy(collider.gameObject);
            StopCoroutine(SpeedBoost());
            StartCoroutine(SpeedBoost());
        }
    }

    IEnumerator SpeedBoost()
    {
        charcontroller.moveSpeed = 10f;
        yield return new WaitForSeconds(5f);
        charcontroller.moveSpeed = 5f;
    }
}
