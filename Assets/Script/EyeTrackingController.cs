using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrackingController : MonoBehaviour
{

    public GameObject lineObj;
    public GameObject leftEyeObj;

    OVREyeGaze eyeGaze;

    void Start()
    {
        eyeGaze = GetComponent<OVREyeGaze>();
    }

    void Update()
    {
        if (eyeGaze == null)return;
        
        //左目の位置
        lineObj.transform.position = leftEyeObj.transform.position;

        if (eyeGaze.EyeTrackingEnabled)
        {
            //左目の回転に視線の角度
            lineObj.transform.rotation = leftEyeObj.transform.rotation * eyeGaze.transform.rotation;
            
            var leftRay = new Ray(leftEyeObj.transform.position, lineObj.transform.forward);

            RaycastHit hit;

            if (Physics.Raycast(leftRay, out hit)) 
            {
                hit.collider.gameObject.GetComponent<CubeColorSet>().IsHit = true;
            }
        }
    }
}
