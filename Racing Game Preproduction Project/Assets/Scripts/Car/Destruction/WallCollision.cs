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



    private void Start()
    {
        playerCar = this.gameObject;
    }




    void Update()
    {
        driftControllerScript = this.gameObject.GetComponent<DriftController>();
        carCurrentSpeed = driftControllerScript.CurrentSpeed;



    }

    private void OnTriggerEnter(Collider wall) //collision detection
    {






        if (wall.gameObject.tag == "Destructable" && driftControllerScript.CurrentSpeed >= driftControllerScript.halfSpeed && this.gameObject.tag == ("Large Car")) 
        {

            Debug.Log("ShouldTrigger");
            Instantiate(destructionModel, this.transform.position, this.transform.rotation);
            Destroy(wall.gameObject);
        }






    }


}




