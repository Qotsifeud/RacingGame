using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PromptScript : MonoBehaviour
{
    public GameObject ImagePrompt;//prompt game object
    Transform MenCam;//the camera in the main menu
    public GameObject Screen;
    private bool PromptActive;//this is to see is the image is active or inactive
    public float distanceFromTarget = 5f;
    public float movementSpeed = 3f;
    public void Start()
    {

        
        MenCam = GameObject.FindGameObjectWithTag("MainCamera").transform;
        



        PromptActive = false;
        Screen.gameObject.SetActive(false);//the screen is currently false
        ImagePrompt.SetActive(false);


    }




    private void OnTriggerEnter(Collider other)//when the player enters the area this triggers the prompt to appear
    {
        if (other.gameObject.tag == "Player")
        {
            PromptActive = true; //this activates the prompt

            if(PromptActive == true)
            {
                ImagePrompt.SetActive(true);

            }

            else if (PromptActive == true && Input.GetKeyDown(KeyCode.E))//if promp active and player presses E key then...
            {
                Screen.gameObject.SetActive(true);//Opens the menu screen etc...



            }

        }

    }

    private void OnTriggerExit(Collider other)//when the [player exits the area the prompt disappears
    {
        if (other.gameObject.tag == "Player")
        {
            PromptActive = false; //this activates the prompt

            if (PromptActive == false)
            {
                ImagePrompt.SetActive(false);

            }


        }


    }





}