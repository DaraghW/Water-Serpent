using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class MultiCameraFollow : MonoBehaviour
{
    public List<Transform> targets;

    public Vector3 offset;

    public float smoothTime = 0.5f;

    private Vector3 velocity;

    public float minZoom = 40f;
    public float maxZoom = 10f;
    public float zoomLimiterX = 50f;
    public float zoomLimiterY = 50f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {

        if (targets.Count == 0)
            return;

        XZoom();
        YZoom();

        Move();
    }

    void XZoom()
    {
        //ZOOOOOMMMMM
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistanceX() / zoomLimiterX);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
        Debug.Log(GetGreatestDistanceX());
    }

    void YZoom()
    {
        //ZOOOOOMMMMM
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistanceY() / zoomLimiterY);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
        Debug.Log(GetGreatestDistanceY());
    }

    void Move()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    float GetGreatestDistanceX()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }

    float GetGreatestDistanceY()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.y;
    }

    Vector3 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        //creates a box around an object.
        var bounds = new Bounds(targets[0].position, Vector3.zero);

        //loops through all of our objects and sets a box around them.
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    }
}
