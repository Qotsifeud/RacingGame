using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class MinimapUI : MonoBehaviour
{
    public Transform CarObj;
    void Update()
    {
       
        Vector3 yrotation = transform.rotation.eulerAngles;
        float xrotation = CarObj.transform.rotation.eulerAngles.x;
        float zrotation = CarObj.transform.rotation.eulerAngles.z;
        yrotation.y = 0f;

     
        transform.rotation = Quaternion.Euler(yrotation);
    }
}

