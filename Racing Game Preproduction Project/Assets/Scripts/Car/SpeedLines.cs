using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLines : MonoBehaviour
{
    public Image speedLineAnimation;
    public DriftController carDriftControllerScript;
    public float alphaValue;


    // Start is called before the first frame update
    void Start()
    {
        alphaValue = 0.0f;//default alpha value
        speedLineAnimation.enabled = true;
        speedLineAnimation.color = new Color (0f, 0f, 0f, alphaValue);//transparent

    }

    // Update is called once per frame
    void Update()
    {

            alphaValue = carDriftControllerScript.CurrentSpeed;
            //match the alpha value with the current speed of the vehicle
        
        if(carDriftControllerScript.CurrentSpeed <= 0)
        {
            alphaValue = 0;
        }
        if(carDriftControllerScript.CurrentSpeed == carDriftControllerScript.TopSpeed)
        {
            alphaValue = 225;//default to max
        }


    }
}
