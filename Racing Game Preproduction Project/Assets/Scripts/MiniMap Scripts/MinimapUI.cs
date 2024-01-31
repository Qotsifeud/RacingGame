using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class MinimapUI : MonoBehaviour
{

    Transform MiniMapCam;//the camera in the main menu
    // Start is called before the first frame update
    void Start()
    {//whatever the tag for the minimap camera is in the game...
        MiniMapCam = GameObject.FindGameObjectWithTag("MMapCam").transform;//getting the transform of the menu camera

    }

    //this makes sure that the icons face the camera no matter the rotation of the player...
    void Update()
    {
        Vector3 direction = (MiniMapCam.position - transform.position).normalized;//gets the direction of the menu camera
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, direction.y, direction.z));//making the prompt face the direction of the minimap cam on x and z axis and y as we want it to tilt up towars the camera and not the player character
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);//turns the prompt face the mencam
    }
}

