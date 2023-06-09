using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    public Camera mainCamera;

    private Ray ray;
    private RaycastHit hitInfo;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = mainCamera.transform.position;
        ray.direction = mainCamera.transform.forward;

        if(Physics.Raycast(ray,out hitInfo))
        {
            transform.position = hitInfo.point;
        }
        else
        {
            transform.position = ray.GetPoint(100f);
        }
    }
}