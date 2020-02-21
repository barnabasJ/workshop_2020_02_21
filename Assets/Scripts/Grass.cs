using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform) print("Foreach loop: " + child);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
