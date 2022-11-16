using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeColorSet : MonoBehaviour
{

    public Material setColor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Renderer>().material = setColor;
    }
}
