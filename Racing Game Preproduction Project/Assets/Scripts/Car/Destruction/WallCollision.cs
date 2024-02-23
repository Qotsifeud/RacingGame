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


        if(smallCar != null)
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

     

        if(car.gameObject.tag == "Large Car" && driftControllerScript.CurrentSpeed >= driftControllerScript.halfSpeed)
        {
            
   
            Instantiate(destructionModel, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }






    }


} 