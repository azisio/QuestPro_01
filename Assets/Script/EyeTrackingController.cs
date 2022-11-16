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
        
        //���ڂ̈ʒu���甭�ˁI
        lineObj.transform.position = leftEyeObj.transform.position;

        if (eyeGaze.EyeTrackingEnabled)
        {
            //���ڂ̉�]�Ɏ����̊p�x
            lineObj.transform.rotation = leftEyeObj.transform.rotation * eyeGaze.transform.rotation;
            

            var leftRay = new Ray(leftEyeObj.transform.position, lineObj.transform.forward);
            Debug.DrawRay(leftRay.origin, leftRay.direction * 30, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(leftRay, out hit)) 
            {
                string name = hit.collider.gameObject.name;
                Debug.Log(name); // �R���\�[���ɕ\��

                hit.collider.gameObject.GetComponent<Renderer>().material = ColorSet[1];
            }

        }

    }
}
