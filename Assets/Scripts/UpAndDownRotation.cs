using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpAndDownRotation : MonoBehaviour
{
    public bool movement = true;
    
    public float degrees = 15f;
    public float distance = .5f;
    public float speed = 1f;
    
    Vector3 offsetPos = new Vector3();
    Vector3 tempPos = new Vector3();

    private void Start()
    {
        offsetPos = transform.position;
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0f, Time.deltaTime * degrees, 0f), Space.World);
        
        tempPos = offsetPos;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * speed) * distance;
 
        transform.position = tempPos;
    }
}