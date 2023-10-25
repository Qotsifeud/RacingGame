using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class PromptRotation : MonoBehaviour
{

    Transform MenCam;//the camera in the main menu
    // Start is called before the first frame update
    void Start()
    {
        MenCam = GameObject.FindGameObjectWithTag("MainCamera").transform;//getting the transform of the menu camera

    }

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = (MenCam.position - transform.position).normalized;//gets the direction of the menu camera
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));//making the prompt face the direction of the men cam on x and z axis and y as we want it to tilt up towars the camera and not the player character
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);//turns the prompt face the mencam
    }
}
