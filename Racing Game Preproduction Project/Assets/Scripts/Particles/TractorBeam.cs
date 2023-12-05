using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{

    public GameObject ScottysBeam;
    public GameObject BeamLight;
    carMovement _carMovementScript;
    public GameObject car;
    public void Start()
    {
        
     _carMovementScript = car.GetComponent<carMovement>();

        
        ScottysBeam.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        { 
        
        ScottysBeam.SetActive(true);
            BeamLight.SetActive(true);


            _carMovementScript.canMove = false;
            _carMovementScript.speed = 0;
            _carMovementScript.acceleration = 0;
            Debug.Log("UsingTractorBeam");



        }

        else if ( Input.GetKeyUp(KeyCode.Space))
        {

            ScottysBeam.SetActive(false);
            BeamLight.SetActive(false);

            _carMovementScript.canMove = true;
            _carMovementScript.speed = 17;
            _carMovementScript.acceleration = 0f;

        }


        //can either press on and off or hold to turn on and let go to turn off

    }
}
