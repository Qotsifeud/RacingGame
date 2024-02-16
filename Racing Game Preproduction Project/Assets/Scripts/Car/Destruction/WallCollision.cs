using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class WallCollision : MonoBehaviour
{

  
    public GameObject destructionModel;
    public DriftController driftControllerScript;
    public float carCurrentSpeed;
    public GameObject brickLocation;
  

    void Update()
    {
        driftControllerScript = this.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;



    }

    private void OnTriggerEnter(Collider wall) //collision detection
    {

        //only issue with this is that if you just happens to get the speed boost before hitting a wall then top speed will increase and you wont be fast enough to go through
        if (driftControllerScript.CurrentSpeed >= driftControllerScript.TopSpeed && wall.gameObject.tag == "Destructable" && this.gameObject.tag == ("Large Car")) //if the game objetc with the tag large car is at a velocity over 20 then it can destroy the wall...
        {
            Transform brickLocation = wall.transform.Find("InstantiateDestroyedWall");
            Destroy(wall.gameObject);
           // Instantiate(destructionModel, wall.transform.position, wall.transform.rotation);
            Instantiate(destructionModel, brickLocation.transform.position, brickLocation.transform.rotation);
           
        }
        /*Adding in the extra tag prevents the small and medium cars from smashing through 
            * walls and allows us toi reuse this script on all three vehicles*/
    }


} 