﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class TreeController : MonoBehaviour
{

    public int health = 0;

    public int healthThreshold = 50;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Sick";
    }

    // Update is called once per frame
    void Update()
    {
        if (health >= healthThreshold)
        {
            gameObject.tag = "Healthy";
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            if (player.HasWater)
            {
                health += 10;
            }
        }
    }
}
