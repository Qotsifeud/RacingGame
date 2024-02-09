using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public Vector3 RingSpeed;//variable for the speed of the rings movement

    // Start is called before the first frame update
    void Start()
    {
        
    }//end of start function

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(RingSpeed * Time.deltaTime);//changing the rotation of the ring particle multiplied by the public speed entered in unity

    }//end of update function
}//end of class
