using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class WallCollision : MonoBehaviour
{
    private Dictionary<GameObject, bool> destructionModelStatus = new Dictionary<GameObject, bool>();
    private Dictionary<GameObject, bool> B1CurrentlyInstantiated = new Dictionary<GameObject, bool>();
    private Dictionary<GameObject, bool> B2CurrentlyInstantiated = new Dictionary<GameObject, bool>();
    private Dictionary<GameObject, bool> B4CurrentlyInstantiated = new Dictionary<GameObject, bool>();
    private Dictionary<GameObject, bool> Bar1Instantiated = new Dictionary<GameObject, bool>();
    private Dictionary<GameObject, bool> Bar2Instantiated = new Dictionary<GameObject, bool>();
    //allows for checking each bool per object that gets destroyed rather then only using the bool once and letting us destroy 1 wall or object at a time.../1 type only once
    //now all can be broken!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    //instantiated objects
    public GameObject destructionModel;
    public GameObject brokenBarrel1;
    public GameObject brokenBarrel2;
    public GameObject brokenBarrel3;
    //barriers...
    public GameObject barrier1Broken;
    public GameObject barrier2Broken;



    private DriftController driftControllerScript;
    public float carCurrentSpeed;

    void Update()
    {
        driftControllerScript = this.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;

    }



    private void OnTriggerEnter(Collider Object) //collision detection
    {



        if (Object.gameObject.tag == "Destructable" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!destructionModelStatus.ContainsKey(Object.gameObject))
            {
                Instantiate(destructionModel, Object.transform.position, Object.transform.rotation);
                destructionModelStatus.Add(Object.gameObject, true);
            }
            else
            {
                Destroy(Object.gameObject);
            }
        }


        if (Object.gameObject.tag == "B1" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B1CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel1, Object.transform.position, Object.transform.rotation);
                B1CurrentlyInstantiated.Add(Object.gameObject, true);
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B2" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B2CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel2, Object.transform.position, Object.transform.rotation);
                B2CurrentlyInstantiated.Add(Object.gameObject, true);
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B4" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B4CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel2, Object.transform.position, Object.transform.rotation);
                B4CurrentlyInstantiated.Add(Object.gameObject, true);
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        //barriers...


        if (Object.gameObject.tag == "Bar1" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!Bar1Instantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(barrier1Broken, Object.transform.position, Object.transform.rotation);
                Bar1Instantiated.Add(Object.gameObject, true);
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }

        if (Object.gameObject.tag == "Bar2" && gameObject.tag == "Large Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!Bar2Instantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(barrier2Broken, Object.transform.position, Object.transform.rotation);
                Bar2Instantiated.Add(Object.gameObject, true);
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


    }


}

