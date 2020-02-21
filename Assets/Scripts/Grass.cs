using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grass : MonoBehaviour
{
    public GameObject Tree;
    public Material healthy;
    public GameObject DeadGrass;
    
    private Boolean makeGreen = false;
    private Boolean grassGrow = false;
    
    // Start is called before the first frame update
    void Start()
    {
        growGrass();
    }

    // Update is called once per frame
    void Update()
    {
        if (Tree.CompareTag("Healthy"))
        {
            greenGrass();
            growGrass();
        }
    }

    private void growGrass()
    {
        if (!grassGrow)
        {
            Vector3 pos = new Vector3(DeadGrass.transform.position.x, DeadGrass.transform.position.y+1.0f, DeadGrass.transform.position.z);
            DeadGrass.transform.position = pos;
        }
    }
    
    private void greenGrass()
    {
        if (!makeGreen)
        {
            foreach (Transform patch in transform)
            {
                foreach (Transform grassBlade in patch.transform) grassBlade.GetComponent<MeshRenderer> ().material = healthy;;
            }
        }
    }
}
