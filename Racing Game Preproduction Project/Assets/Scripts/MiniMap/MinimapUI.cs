using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class MinimapUI : MonoBehaviour
{
    public Transform CarObj;
    void Update()
    {

        transform.position = CarObj.transform.position;

        //Vector3 yrotation = transform.rotation.eulerAngles;
        //float xrotation = CarObj.transform.rotation.eulerAngles.x;
        //float zrotation = CarObj.transform.rotation.eulerAngles.z;



        //yrotation.y = 0f;



     
        //transform.rotation = Quaternion.Euler(yrotation);

        float yRotation = CarObj.transform.rotation.eulerAngles.y;
        Quaternion newRotation = Quaternion.Euler(0, yRotation, 0);
        transform.rotation = newRotation;

    }
}

