using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    private Transform player;

    private bool isCarried = false;
    private Vector3 floatingPosition = new Vector3(0, 6f, 0);

    private void OnTriggerEnter(Collider other)
    {
        isCarried = true;
        player = other.transform;
        other.GetComponent<PlayerController>().HasWater = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCarried)
        {
            transform.position = player.position + floatingPosition;
        }        
    }
}
