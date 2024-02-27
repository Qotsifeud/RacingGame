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
    public GameObject playerCar;
    public GameObject laregCar;
    public GameObject mediumCar;
    public GameObject smallCar;




    private void Start()
    {
        smallCar = GameObject.FindGameObjectWithTag("Small Car");
        mediumCar = GameObject.FindGameObjectWithTag("Medium Car");
        laregCar = GameObject.FindGameObjectWithTag("Large Car");


        if (smallCar != null)
        {
            playerCar = smallCar;
        }

        if (mediumCar != null)
        {
            playerCar = mediumCar;
        }

        if (laregCar != null)
        {
            playerCar = laregCar;
        }



    }



    void Update()
    {
        driftControllerScript = playerCar.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;



    }

    private void OnCollisionEnter(Collision car) //collision detection
    {



        if (car.gameObject.tag == "Large Car" && driftControllerScript.CurrentSpeed >= driftControllerScript.halfSpeed)
        {


            Instantiate(destructionModel, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }






    }


}


/*

using UnityEngine;

public class WallCollision : MonoBehaviour
{
    public GameObject destructionModel;
    private DriftController driftControllerScript;
    public float carCurrentSpeed;
    public GameObject playerCar;
    public GameObject largeCar;
    public GameObject mediumCar;
    public GameObject smallCar;
    private Vector3 innerBoxColliderSize;
    private Vector3 outerBoxColliderSize;
    private BoxCollider innerBoxCollider;
    private BoxCollider outerBoxCollider;
    private bool hasColliders;

    private void Start()
    {


        smallCar = GameObject.FindGameObjectWithTag("Small Car");
        mediumCar = GameObject.FindGameObjectWithTag("Medium Car");
        largeCar = GameObject.FindGameObjectWithTag("Large Car");

        if (smallCar != null)
        {
            playerCar = smallCar;
        }
        else if (mediumCar != null)
        {
            playerCar = mediumCar;
        }
        else if (largeCar != null)
        {
            playerCar = largeCar;
        }


        if (!hasColliders)
        {
            innerBoxColliderSize = new Vector3(1.5f, 1.5f, 10.0f); // Adjust the size according to your wall size
            outerBoxColliderSize = new Vector3(1, 1, 1);//matching the wall size
            // Create upper and lower Box Colliders
            innerBoxCollider = gameObject.AddComponent<BoxCollider>();
            outerBoxCollider = gameObject.AddComponent<BoxCollider>();


            innerBoxCollider.isTrigger = false;
            innerBoxCollider.size = innerBoxColliderSize;
            outerBoxCollider.isTrigger = true;
            outerBoxCollider.size = outerBoxColliderSize;

            hasColliders = true;
        }


    }

    private void Update()
    {
        driftControllerScript = playerCar.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Large Car"))
        {
            Debug.Log("The car can smash the wall");
            outerBoxCollider.enabled = false;
            // When the outer collider detects a car, set the inner collider to be a trigger
            innerBoxCollider.isTrigger = true;

            if (driftControllerScript.CurrentSpeed >= driftControllerScript.halfSpeed)
            {
                Debug.Log("The car has smashed the wall");
                Instantiate(destructionModel, transform.position, transform.rotation);
                Destroy(gameObject);
            }
        }
    }
}

*/