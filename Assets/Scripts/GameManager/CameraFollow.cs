using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{   
    public Vector3 Offset;
    private Vector3 CentralPoint;
    public float SmoothTime = .5f;
    public float MinSize = 8.0f;
    public float ZoomOffset = 5.0f;
    public float ZoomLimiter = 10.0f;

    public Transform[] Targets;
    private Vector3 Velocity;
    private float ZoomSpeed;
    private Camera Cam;

    private void Awake()
    {
        Cam = GetComponentInChildren<Camera>();
    }

    void FixedUpdate()
    {
        Move();
        Zoom();
    }

    void Move()
    {
        GetCenterPoint();
        Vector3 newPosition = CentralPoint + Offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref Velocity, SmoothTime);
    }

    private void Zoom()
    {
        float requiredSize = GetNewSize();
        Cam.orthographicSize = Mathf.SmoothDamp(Cam.orthographicSize, requiredSize, ref ZoomSpeed, SmoothTime);
    }

    /*void GetTargets()
     {
        //Targets = GameObject.FindGameObjectsWithTag("Player");
        int i = 0;
        foreach (GameObject GO in GameObject.FindGameObjectsWithTag("Player"))
        {
            Targets[i] = GO;
            i++;
        }
     }*/

   void GetCenterPoint()
    {
        Bounds bounds = new Bounds(Targets[0].transform.position, Vector3.zero);
        for(int i = 0; i < Targets.Length; i++)
            bounds.Encapsulate(Targets[i].transform.position);

        CentralPoint = bounds.center;
    }


    float GetNewSize()
    {
        Vector3 targetPoint;
        Vector3 newTargetPoint;

        Vector3 newPoint = transform.InverseTransformPoint(CentralPoint);

        float size = 0f;

        for (int i = 0; i < Targets.Length; i++)
        {
            if (!Targets[i].gameObject.activeSelf)
                continue;

            targetPoint = transform.InverseTransformPoint(Targets[i].position);

            newTargetPoint = targetPoint - newPoint;

            size = Mathf.Max(size, Mathf.Abs(newTargetPoint.y));

            size = Mathf.Max(size, Mathf.Abs(newTargetPoint.x) / Cam.aspect);
        }

        size += ZoomOffset;

        size = Mathf.Max(size, MinSize);

        return size;
    }
}