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

    public float smallCarWallCollisionForce = 2;//the amoundt of drag added to the car during that time
    public float scCollisionTime = 1;// how long the push back lasts
    public float mediumCarWallCollisionForce = 1;//the amoundt of drag added to the car during that time
    public float mcCollisionTime = 0.5f;// how long the push back lasts

    public bool smallCaraTrigger;
    public bool mediumCarTrigger;


    private DriftController driftControllerScript;
    public float carCurrentSpeed;

    private void Start()
    {//DEFAULT FALSE
        smallCaraTrigger = false;
        mediumCarTrigger = false;
    }



    void Update()
    {
        driftControllerScript = this.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;

        if (smallCaraTrigger)
        {
            Debug.Log("trigger small car coroutine");
            StartCoroutine(SlowDownSmall());
        }

        if (mediumCarTrigger)
        {
            StartCoroutine(SlowDownMed());
        }



    }
    IEnumerator SlowDownMed()//top speed reduced by 1 third for the medium car
    {

        // Apply force in the opposite direction
        Rigidbody carRigidbody = driftControllerScript.GetComponent<Rigidbody>();
        carRigidbody.drag = mediumCarWallCollisionForce; // Adjust the drag coefficient to slow down the car

        yield return new WaitForSeconds(mcCollisionTime);

        carRigidbody.drag = 0f; // Reset drag to normal

        mediumCarTrigger = false;
    }

    IEnumerator SlowDownSmall()//top speed reduced by 2 thirds for the small car
    {
        
        // Apply force in the opposite direction
        Rigidbody carRigidbody = driftControllerScript.GetComponent<Rigidbody>();
        carRigidbody.drag = smallCarWallCollisionForce; // Adjust the drag coefficient to slow down the car

        yield return new WaitForSeconds(scCollisionTime);

     
        carRigidbody.drag = 0f; // Reset drag to normal

        smallCaraTrigger = false;
    }

    private void OnTriggerEnter(Collider Object) //collision detection
    {
        
        //Large Car//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

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


        //Medium Car/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Object.gameObject.tag == "Destructable" && gameObject.tag == "Medium Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!destructionModelStatus.ContainsKey(Object.gameObject))
            {
                Instantiate(destructionModel, Object.transform.position, Object.transform.rotation);
                destructionModelStatus.Add(Object.gameObject, true);

                mediumCarTrigger = true;
                
            }
            else
            {
                Destroy(Object.gameObject);
            }
        }


        if (Object.gameObject.tag == "B1" && gameObject.tag == "Medium Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B1CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel1, Object.transform.position, Object.transform.rotation);
                B1CurrentlyInstantiated.Add(Object.gameObject, true);

                mediumCarTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B2" && gameObject.tag == "Medium Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B2CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel2, Object.transform.position, Object.transform.rotation);
                B2CurrentlyInstantiated.Add(Object.gameObject, true);

                mediumCarTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B4" && gameObject.tag == "Medium Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B4CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel2, Object.transform.position, Object.transform.rotation);
                B4CurrentlyInstantiated.Add(Object.gameObject, true);

                mediumCarTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        //barriers...


        if (Object.gameObject.tag == "Bar1" && gameObject.tag == "Medium Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!Bar1Instantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(barrier1Broken, Object.transform.position, Object.transform.rotation);
                Bar1Instantiated.Add(Object.gameObject, true);

                mediumCarTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }

        if (Object.gameObject.tag == "Bar2" && gameObject.tag == "Medium Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!Bar2Instantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(barrier2Broken, Object.transform.position, Object.transform.rotation);
                Bar2Instantiated.Add(Object.gameObject, true);

                mediumCarTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }



        //Small Car///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        if (Object.gameObject.tag == "Destructable" && gameObject.tag == "Small Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!destructionModelStatus.ContainsKey(Object.gameObject))
            {
                Instantiate(destructionModel, Object.transform.position, Object.transform.rotation);
                destructionModelStatus.Add(Object.gameObject, true);

                smallCaraTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject);
            }
        }


        if (Object.gameObject.tag == "B1" && gameObject.tag == "Small Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B1CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel1, Object.transform.position, Object.transform.rotation);
                B1CurrentlyInstantiated.Add(Object.gameObject, true);

                smallCaraTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B2" && gameObject.tag == "Small Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B2CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel2, Object.transform.position, Object.transform.rotation);
                B2CurrentlyInstantiated.Add(Object.gameObject, true);

                smallCaraTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        if (Object.gameObject.tag == "B4" && gameObject.tag == "Small Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!B4CurrentlyInstantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(brokenBarrel2, Object.transform.position, Object.transform.rotation);
                B4CurrentlyInstantiated.Add(Object.gameObject, true);

                smallCaraTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }


        //barriers...


        if (Object.gameObject.tag == "Bar1" && gameObject.tag == "Small Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!Bar1Instantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(barrier1Broken, Object.transform.position, Object.transform.rotation);
                Bar1Instantiated.Add(Object.gameObject, true);

                smallCaraTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }

        if (Object.gameObject.tag == "Bar2" && gameObject.tag == "Small Car" && carCurrentSpeed >= driftControllerScript.halfSpeed)
        {
            if (!Bar2Instantiated.ContainsKey(Object.gameObject)) // Check if destruction model is not already instantiated
            {
                Instantiate(barrier2Broken, Object.transform.position, Object.transform.rotation);
                Bar2Instantiated.Add(Object.gameObject, true);

                smallCaraTrigger = true;
            }
            else
            {
                Destroy(Object.gameObject); // Destroy the collided wall object if destruction model is already instantiated
            }


        }



    }


}

