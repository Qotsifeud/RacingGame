using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptScript : MonoBehaviour
{
    public GameObject imagePrompt; // Prompt game object
    public Material defaultMaterial; // Material for default (black) color
    public Material greenMaterial; // Material for green color
    public GameObject menuScreen;

    private bool active = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetObjectColor(defaultMaterial); // Set the initial color to default (black)
        active = false;
        menuScreen.SetActive(false);
    }

    void Update()
    {
        if (active && Input.GetKeyDown(KeyCode.E))
        {
            menuScreen.SetActive(true);
            Debug.Log("You pressed E");
            SetObjectColor(greenMaterial); // Change the color to green
            //imagePrompt.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            MenuCharacter.InMenuScreen = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetObjectColor(greenMaterial); // Change the color to green on trigger enter
           // imagePrompt.SetActive(true);
            active = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            SetObjectColor(defaultMaterial); // Change the color back to default (black) on trigger exit
            active = false;
          //  imagePrompt.SetActive(false);
            menuScreen.SetActive(false);
        }
    }

    void SetObjectColor(Material newMaterial)
    {
        Renderer renderer = imagePrompt.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.material = newMaterial;
        }
    }
}