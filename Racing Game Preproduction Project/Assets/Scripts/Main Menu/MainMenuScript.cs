using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void PlayeTheGame()
    {//opens the game scene//just for play testing


        SceneManager.LoadScene("GCU RaceTrack");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;





    }

    public void BackToMenu() 
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void CloseMenuScreen() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //MenuCharacter.InMenuScreen = false;
       



    }









}
