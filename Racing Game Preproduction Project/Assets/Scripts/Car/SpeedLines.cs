using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SpeedLines : MonoBehaviour
{
    public Image speedOmeterPointer;
    public Image speedLineAnimation;
    public DriftController carDriftControllerScript;
    private float alphaValue;
    public GameObject speedLineGameObject;
    [SerializeField] Animator speedlineAnim;
    public float animSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        carDriftControllerScript = GetComponent<DriftController>();
        alphaValue = 0.0f; // default alpha value
        speedLineAnimation.enabled = true;
        // Set the image color to white and transparent
        speedLineAnimation.color = new Color(1f, 1f, 1f, alphaValue);

        speedLineGameObject = GameObject.Find("SpeedLines");
        speedlineAnim = speedLineGameObject.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        alphaValue = carDriftControllerScript.CurrentSpeed / carDriftControllerScript.TopSpeed;
        alphaValue = Mathf.Clamp01(alphaValue);
        speedLineAnimation.color = new Color(1f, 1f, 1f, alphaValue);
        speedlineAnim.SetFloat("animationSpeed", alphaValue);

        //this float uses the 90 degree angle as the start for no speed and gradually rotates to 0 degrees/ upwards when at the cars top speed
        //similar to the previous code for the windstreaks it rotates based on car speet/ the cars top speed when incramenting up and down
        float pointerTargetPositionLarge = Mathf.Lerp(90f, 45f, carDriftControllerScript.CurrentSpeed / carDriftControllerScript.TopSpeed);
        float pointerTargetPositionMedium = Mathf.Lerp(90f, 30f, carDriftControllerScript.CurrentSpeed / carDriftControllerScript.TopSpeed);
        float pointerTargetPositionSmall = Mathf.Lerp(90f, 15f, carDriftControllerScript.CurrentSpeed / carDriftControllerScript.TopSpeed);

        if(carDriftControllerScript.gameObject.tag == ("Large Car"))
        {
            speedOmeterPointer.transform.rotation = Quaternion.Euler(0f, 0f, pointerTargetPositionLarge);
        }
        if (carDriftControllerScript.gameObject.tag == ("Medium Car"))
        {
            speedOmeterPointer.transform.rotation = Quaternion.Euler(0f, 0f, pointerTargetPositionMedium);
        }
        if (carDriftControllerScript.gameObject.tag == ("Small Car"))
        {
            speedOmeterPointer.transform.rotation = Quaternion.Euler(0f, 0f, pointerTargetPositionSmall);
        }



    }
}
