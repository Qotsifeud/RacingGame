using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class MiniMapPickup : MonoBehaviour
{
    public Transform pickUp;
    void Update()
    {
        if(pickUp != null)
        {

            transform.position = pickUp.transform.position;






            //transform.rotation = Quaternion.Euler(yrotation);

            float yRotation = pickUp.transform.rotation.eulerAngles.y;
            Quaternion newRotation = Quaternion.Euler(0, yRotation, 0);
            transform.rotation = newRotation;
        }

        else
        {
            Destroy(this.gameObject);
        }


    }
}

