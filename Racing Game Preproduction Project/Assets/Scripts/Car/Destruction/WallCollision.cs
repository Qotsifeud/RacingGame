using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class WallCollision : MonoBehaviour
{

    //instantiated objects
    public GameObject destructionModel;
    public GameObject brokenBarrel1;
    public GameObject brokenBarrel2;
    public GameObject brokenBarrel3;




    private DriftController driftControllerScript;
    public float carCurrentSpeed;
    private bool destructionModelInstantiated = false;



    void Update()
    {
        driftControllerScript = this.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;


    }



    private void OnTriggerEnter(Collider Object) //collision detection
    {



        if (Object.gameObject.tag == "Destructable" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!destructionModelInstantiated) // Check if destruction model is not already instantiated
            {
                Instantiate(destructionModel, Object.transform.position, Object.transform.rotation);
                destructionModelInstantiated = true; // Set flag to true indicating destruction model is instantiated
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B1" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!destructionModelInstantiated) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel1, Object.transform.position, Object.transform.rotation);
                destructionModelInstantiated = true; // Set flag to true indicating destruction model is instantiated
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B2" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!destructionModelInstantiated) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel2, Object.transform.position, Object.transform.rotation);
                destructionModelInstantiated = true; // Set flag to true indicating destruction model is instantiated
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B4" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!destructionModelInstantiated) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel2, Object.transform.position, Object.transform.rotation);
                destructionModelInstantiated = true; // Set flag to true indicating destruction model is instantiated
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }




    }


}

