using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrackingController : MonoBehaviour
{

    public GameObject lineObj;

    OVREyeGaze eyeGaze;

    // Start is called before the first frame update
    void Start()
    {
        eyeGaze = GetComponent<OVREyeGaze>();
    }

    // Update is called once per frame
    void Update()
    {
        if (eyeGaze == null)return;

        Debug.Log(eyeGaze.EyeTrackingEnabled);

        if (eyeGaze.EyeTrackingEnabled)
        {
            lineObj.transform.rotation = eyeGaze.transform.rotation;
        }

    }
}
