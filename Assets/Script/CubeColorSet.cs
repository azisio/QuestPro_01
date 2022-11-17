using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorSet : MonoBehaviour
{

    public Material defoColor;
    public Material hitColor;

    [System.NonSerialized]
    public bool IsHit = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Renderer>().material = defoColor;


        if (IsHit)
        {
            IsHit = false;
            this.GetComponent<Renderer>().material = hitColor;
        }


    }
}
