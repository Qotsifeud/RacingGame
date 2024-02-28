using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shrapn : MonoBehaviour
{
    private Rigidbody thisBody;
    public float useTheForce = 10;


    private void Start()
    {
        
        thisBody = this.gameObject.GetComponent<Rigidbody>();
        thisBody.AddForce(transform.forward * useTheForce, ForceMode.Impulse);

     


    }

}
