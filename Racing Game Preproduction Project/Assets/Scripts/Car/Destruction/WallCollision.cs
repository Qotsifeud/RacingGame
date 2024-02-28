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









    void Update()
    {
        driftControllerScript = this.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;



    }

    private void OnTriggerEnter(Collider Wall) //collision detection
    {



        if (Wall.gameObject.tag == "Destructable" && this.gameObject.tag == ("Large Car")) 
        {
            

            if (driftControllerScript.CurrentSpeed >= driftControllerScript.halfSpeed)
            {

                Instantiate(destructionModel, Wall.transform.position, Wall.transform.rotation);
                Destroy(Wall.gameObject);
                
            }
        }






    }


}

