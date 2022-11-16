using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeTrackingController : MonoBehaviour
{

    public GameObject lineObj;
    public GameObject leftEyeObj;

    public Material[] ColorSet = new Material[2];


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

        Debug.Log(eyeGaze.TrackingMode);
        
        //左目の位置から発射！
        lineObj.transform.position = leftEyeObj.transform.position;

        if (eyeGaze.EyeTrackingEnabled)
        {
            //左目の回転に視線の角度
            lineObj.transform.rotation = leftEyeObj.transform.rotation * eyeGaze.transform.rotation;
            

            var leftRay = new Ray(leftEyeObj.transform.position, lineObj.transform.forward);
            Debug.DrawRay(leftRay.origin, leftRay.direction * 30, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(leftRay, out hit)) 
            {
                string name = hit.collider.gameObject.name;
                Debug.Log(name); // コンソールに表示

                hit.collider.gameObject.GetComponent<Renderer>().material = ColorSet[1];
            }

        }

    }
}
