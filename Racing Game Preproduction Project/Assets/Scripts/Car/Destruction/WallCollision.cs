using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class WallCollision : MonoBehaviour
{


    public GameObject destructionModel;
    private DriftController driftControllerScript;
    public float carCurrentSpeed;
    private bool destructionModelInstantiated = false;



    void Update()
    {
        driftControllerScript = this.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;



    }

    private void OnTriggerEnter(Collider Wall) //collision detection
    {



        if (Wall.gameObject.tag == "Destructable" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!destructionModelInstantiated) // Check if destruction model is not already instantiated
            {
                Instantiate(destructionModel, Wall.transform.position, Wall.transform.rotation);
                destructionModelInstantiated = true; // Set flag to true indicating destruction model is instantiated
            }
            else
            {
                Destroy(Wall.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }





        }


    }
}

