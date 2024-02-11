using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoofRiding : MonoBehaviour
{
    public float currentMass;

    public bool IsTriggering;


    public void Start()
    {
        currentMass = this.gameObject.GetComponent<Rigidbody>().mass;

        IsTriggering = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == ("UpsideDown"))
        {

            this.gameObject.GetComponent<Rigidbody>().mass = 1;//this should flip the mass as in making the car fly upwards rather than down to the ground
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            IsTriggering = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("UpsideDown"))
        {

            this.gameObject.GetComponent<Rigidbody>().mass = currentMass;//this should flip the mass as in making the car fly upwards rather than down to the ground
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            IsTriggering = false;

        }

    }




}
