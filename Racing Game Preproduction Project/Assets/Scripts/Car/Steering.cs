using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Steering : MonoBehaviour
{
    public float modifier = 0.1f;   //Ideally time.deltaTime
  
    DriftController thisCar;
    Vector3 initRotation;

    // Start is called before the first frame update
    void Start()
    {
        // Get car
        thisCar = transform.parent.GetComponent<DriftController>();
        initRotation = transform.localEulerAngles;  // Rotation relative to parent (car)
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate this according to the rotation input value
        float rotate = thisCar.inTurn * thisCar.Rotate * modifier;
       

      

        if(DriftController.DriveF)
        {
            transform.localEulerAngles = initRotation + new Vector3(5, rotate, 0f);
        }
        else if (DriftController.DriveB)
        {
            transform.localEulerAngles = initRotation + new Vector3(-5, rotate, 0f);
        }

        else
        {
            transform.localEulerAngles = initRotation + new Vector3(0f, rotate, 0f);
        }





    }
}
