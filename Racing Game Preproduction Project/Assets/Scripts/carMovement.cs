using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carMovement : MonoBehaviour
{
    public Rigidbody rb;
    public Transform car;
    public float speed = 17;

    public Vector3 rotationRight = new Vector3(0, 30, 0);
    public Vector3 rotationLeft = new Vector3(0, -30, 0);

    public Vector3 forward = new Vector3(0, 0, 1);
    public Vector3 backward = new Vector3(0, 0, -1);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            transform.Translate(forward * speed * Time.deltaTime);
        }
        if(Input.GetKey("s")) 
        {
            transform.Translate(backward * speed * Time.deltaTime);
        }
        if(Input.GetKey("d"))
        {
            Quaternion deltaRotationRight = Quaternion.Euler(rotationRight * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationRight);
        }
        if(Input.GetKey("a")) 
        {
            Quaternion deltaRotationLeft = Quaternion.Euler(rotationLeft * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotationLeft);
        }


    }
}
