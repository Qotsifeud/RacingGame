using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToRace : MonoBehaviour
{
    public Image fadingToBlackImage;
    public GameObject imageHolder;
    public float timeOfFade = 1.0f;
    public GameObject menuAudio;
    public GameObject driftAudio;
    public GameObject newTrack, kamesTrack;
    private AudioSource mainMenuAudioClip;
    private AudioSource menuDriftAudio;

    public void Start()
    {
        mainMenuAudioClip = menuAudio.GetComponent<AudioSource>();//getting /assigning the audio source (not clip)
        menuDriftAudio = driftAudio.GetComponent<AudioSource>();
    }

    public void ChooseTrack()
    {
        if(newTrack.activeInHierarchy)
        {
            newTrack.SetActive(false);
            kamesTrack.SetActive(true);
        }
        else if(kamesTrack.activeInHierarchy)
        {
            kamesTrack.SetActive(false);
            newTrack.SetActive(true);
        }
    }

    public void ChooseTrackReverse()
    {
        if (newTrack.activeInHierarchy)
        {
            newTrack.SetActive(false);
            kamesTrack.SetActive(true);
        }
        else if (kamesTrack.activeInHierarchy)
        {
            kamesTrack.SetActive(false);
            newTrack.SetActive(true);
        }
    }

    public void TestTrack()
    {
        imageHolder.SetActive(true);
        fadingToBlackImage.enabled = true;
        StartCoroutine(FadingToBlack());
    }

    //took from the LapCounter script...
    //reused the same method for the sudio fading as well (pretty cool)...
    IEnumerator FadingToBlack()//fading out
    {
        
        float elapsedTime = 0f;
        Color imageColour = fadingToBlackImage.color;
        float menuMusicVolume = mainMenuAudioClip.volume;
        float driftVolume = menuDriftAudio.volume;
        //while the pre set time is greater than elapse time itll change the alpha value on the image, increasing it to black
        while (elapsedTime < timeOfFade)
        {
            elapsedTime += Time.deltaTime;
            imageColour.a = Mathf.Lerp(0f, 1f, elapsedTime / timeOfFade);
            //updating the image with the new alpha value
            fadingToBlackImage.color = imageColour;
            mainMenuAudioClip.volume = Mathf.Lerp(menuMusicVolume, 0f, elapsedTime / timeOfFade);
            menuDriftAudio.volume = Mathf.Lerp(driftVolume, 0f, elapsedTime / timeOfFade);
            yield return null;
        }

        if(newTrack.activeInHierarchy)
        {
            SceneManager.LoadScene("NewTrack");
        }
        else if(kamesTrack.activeInHierarchy)
        {
            SceneManager.LoadScene("KamesTrack");
        }
        

    }
}
