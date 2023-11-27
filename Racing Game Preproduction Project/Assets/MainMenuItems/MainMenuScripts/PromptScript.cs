using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PromptScript : MonoBehaviour
{
    public GameObject ImagePrompt;//prompt game object
    
    
    public bool Active = false;
    public float distanceFromTarget = 5f;
    public float movementSpeed = 3f;
  //  public Image MenuScreen;
    public GameObject MenuScreen;




    public void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;   
        Cursor.visible = false;
        ImagePrompt.SetActive(false);
        Active = false;
        // MenuScreen.enabled = false;//the menus screen is defaulted to false
        MenuScreen.SetActive(false);
    }

    public void Update()
    {

        if (Active == true && Input.GetKeyDown(KeyCode.E))//if promp active and player presses E key then...
        {

            //  MenuScreen.enabled = true;//the menus screen is defaulted to false
            MenuScreen.SetActive(true);
            Debug.Log("YouPressedE");
            ImagePrompt.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    private void OnTriggerEnter(Collider other)//when the player enters the area this triggers the prompt to appear
    {
        if (other.gameObject.tag == "Player")
        {
            ImagePrompt.SetActive(true);
            Active = true;
         

        }

    }

    private void OnTriggerExit(Collider other)//when the [player exits the area the prompt disappears
    {
        if (other.gameObject.tag == "Player")
        {
            Active = false;
                ImagePrompt.SetActive(false);


            //this is here for now until we figure out the designs and the actual way we want players to exit the menu screens 
            //MenuScreen.enabled = false;//the menus screen is defaulted to false
            MenuScreen.SetActive(false);
        }


    }


}