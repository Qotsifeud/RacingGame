using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Image fadingToBlackImage;
  
    public float timeOfFade = 1.0f;
    public GameObject levelAudio;
    private AudioSource levelAudioSource;
    public void Start()
    {
        levelAudioSource = levelAudio.GetComponent<AudioSource>();//getting /assigning the audio source (not clip)
       
    }

    public void PlayeTheGame()
    {//opens the game scene//just for play testing


        SceneManager.LoadScene("GCU RaceTrack");
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void BackToMenu()
    {
        
        fadingToBlackImage.enabled = true;
        StartCoroutine(FadingToBlack());
        
    }
    public void CloseMenuScreen() {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //MenuCharacter.InMenuScreen = false;
    }



    IEnumerator FadingToBlack()//fading out
    {

        float elapsedTime = 0f;
        Color imageColour = fadingToBlackImage.color;
        float menuMusicVolume = levelAudioSource.volume;
        
        //while the pre set time is greater than elapse time itll change the alpha value on the image, increasing it to black
        while (elapsedTime < timeOfFade)
        {
            elapsedTime += Time.deltaTime;
            imageColour.a = Mathf.Lerp(0f, 1f, elapsedTime / timeOfFade);
            //updating the image with the new alpha value
            fadingToBlackImage.color = imageColour;
            levelAudioSource.volume = Mathf.Lerp(menuMusicVolume, 0f, elapsedTime / timeOfFade);
            
            yield return null;
        }

        SceneManager.LoadScene("MainMenu");


    }













}
