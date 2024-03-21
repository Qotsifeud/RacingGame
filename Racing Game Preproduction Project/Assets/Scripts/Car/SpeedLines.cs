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
    public float linesAppear = 45f;
    public GameObject speedLineGameObject;
    [SerializeField] Animator speedlineAnim;
    public float animSpeed = 1f;

    //default values for the angle of the pointer on the speedometer...
    public float smallCarSpeedOmeterAngle = 15f;
    public float mediumCarSpeedOmeterAngle = 30f;
    public float largeCarSpeedOmeterAngle = 45f;

    public GameObject windAudioSource;
    private AudioSource windRushing;
    public GameObject carEngineAudioObj;
    private AudioSource CarEngine;


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
        windRushing = windAudioSource.GetComponent<AudioSource>();//getting the wind audiosource
        CarEngine = carEngineAudioObj.GetComponent<AudioSource>();//get/set of car audio
    }

    // Update is called once per frame
    void Update()
    {
        linesAppear = carDriftControllerScript.halfSpeed;
        alphaValue =(carDriftControllerScript.CurrentSpeed -linesAppear)/ (carDriftControllerScript.TopSpeed - linesAppear);
        alphaValue = Mathf.Clamp01(alphaValue);
        speedLineAnimation.color = new Color(1f, 1f, 1f, alphaValue);
        speedlineAnim.SetFloat("animationSpeed", alphaValue);

        //this float uses the 90 degree angle as the start for no speed and gradually rotates to 0 degrees/ upwards when at the cars top speed
        //similar to the previous code for the windstreaks it rotates based on car speet/ the cars top speed when incramenting up and down
        float pointerTargetPositionLarge = Mathf.Lerp(90f, largeCarSpeedOmeterAngle, carDriftControllerScript.CurrentSpeed / carDriftControllerScript.TopSpeed);
        float pointerTargetPositionMedium = Mathf.Lerp(90f, mediumCarSpeedOmeterAngle, carDriftControllerScript.CurrentSpeed / carDriftControllerScript.TopSpeed);
        float pointerTargetPositionSmall = Mathf.Lerp(90f, smallCarSpeedOmeterAngle, carDriftControllerScript.CurrentSpeed / carDriftControllerScript.TopSpeed);


        float targetVolume = Mathf.Lerp(0f, 1f, alphaValue);

        //setting a min and max volume and pitch for the engine, made it so you can always hear then engine even if car not moving, more realistic that way.
        //same as before increased speed means higher volume but also change of engine pitch/ speed essentially...
        float minimumWindVol = 0f;
        float maximumWindVol = 0.5f;
        float minimumVolume = 0.2f;
        float maximumVolume = 0.6f;
        float minimumPitch = 0.5f;
        float maximumPitch = 2f;
        //could make adjustable per car type and more designer friendly later//
        float tergetEngineVolume = Mathf.Lerp(minimumVolume, maximumVolume, alphaValue);
        float targetWindVolume = Mathf.Lerp(minimumWindVol, maximumWindVol, alphaValue);
        float targetEnginePitch = Mathf.Lerp(minimumPitch, maximumPitch, alphaValue);
        tergetEngineVolume = Mathf.Max(tergetEngineVolume, minimumVolume);
        CarEngine.volume = tergetEngineVolume;
        CarEngine.pitch = targetEnginePitch;
        //made a new volume with its own max and min for the wind.
        windRushing.volume = targetWindVolume;
        windRushing.pitch = targetEnginePitch;


        if (carDriftControllerScript.gameObject.tag == ("Large Car"))
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
