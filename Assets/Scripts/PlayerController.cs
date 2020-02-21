using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed;
    
    private Vector3 destination;
    private Vector3 RayHitPoint;

    private bool hasWater = false;

    public bool HasWater
    {
        get => hasWater;
        set => hasWater = value;
    }


    // Start is called before the first frame update
    void Start()
    {
        destination = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position + Vector3.zero);

        Ray RayCast = Camera.main.ScreenPointToRay(Input.mousePosition);

        float hitDist = 0;
        
        if (Input.GetMouseButtonDown(0))
        {
            if (playerPlane.Raycast(RayCast, out hitDist))
            {
                destination = RayCast.GetPoint(hitDist);
            }
        }
        
        transform.position = Vector3.MoveTowards(transform.position, destination, movementSpeed * Time.deltaTime);
    }
}
