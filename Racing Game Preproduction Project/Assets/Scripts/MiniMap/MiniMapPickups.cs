using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class MiniMapPickup : MonoBehaviour
{
    public Vector3 rotation;
    public Transform pickUp;
    void Update()
    {
        if(pickUp != null)
        {

            transform.position = pickUp.transform.position;

            transform.rotation = Quaternion.Euler(rotation);
        }

        else
        {
            Destroy(this.gameObject);
        }


    }
}

