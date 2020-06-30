using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    public Transform target;
    public float speed = 1.0f;
    public Vector3 offset;

    void Update()
    {
        float step = speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position + offset, step);
    }
}
