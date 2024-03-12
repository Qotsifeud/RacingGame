using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    public GameObject EndOfRaceStance;//this appears at the end of each race
    public GameObject playerDisplaySpot;
    public GameObject carDisplaySpot;
    public GameObject playerCharacter;
    public GameObject playersCar;
    public Vector3 playerDisplayPosition;
    public Vector3 carDisplayPosition;

    public GameObject CarCamera;//disable afte rthe race
    //the above variables ar for the winning game over screen at the end of each race
    public TextMeshProUGUI lapCounter;
    public TextMeshProUGUI startSign;
    public TextMeshProUGUI finishSign;
    public TextMeshProUGUI raceCompleteSign;
    public Image fadingToBlackImage;
    public GameObject raceObjects;//this holds all objects wihtin the canvas regarding the race/ need to be used during the race
    public GameObject afterRaceObjects;//this holds to other game objects on the canvas that we want visable at the end of the race only.
    public Rigidbody theCarsRb;

    private bool raceEnded = false;
    private bool afterRaceComplete = false;
    public float timeOfFade = 3.0f;
    public GameObject gameOver;

    public int currentNumberOfLaps = 1;
    public int maxLaps = 3;

    public bool[] checkPopints = new bool[5];
    

   public void Start()
    {
        theCarsRb = GetComponent<Rigidbody>();
        theCarsRb.isKinematic = false;
        CarCamera.SetActive(true);
        raceObjects.SetActive(true);//lets us see what we need on the canvas during the race
        afterRaceObjects.SetActive(false);//canvis ibjects only for when race is complete

        raceCompleteSign.enabled = false;
        startSign.enabled = true;
        finishSign.enabled = false;
        EndOfRaceStance.SetActive(false);//default off


        playerCharacter = GameObject.Find("Player");//the player character is the object named player
        playersCar = this.gameObject;//this car is the car object

         playerDisplayPosition = playerDisplaySpot.transform.position;
         carDisplayPosition = carDisplaySpot.transform.position;


    }

    public void Update()
    {
        lapCounter.text = "Lap " + currentNumberOfLaps.ToString() + "/3";

        if (!raceEnded && currentNumberOfLaps > maxLaps)
        {
            raceEnded = true;
            AfterRace();//after race function instead of coroutine.
        }

        if (currentNumberOfLaps == 1)
        {
            startSign.enabled = true;
        }

        if(currentNumberOfLaps == 2)
        {
            startSign.enabled = false;
        }

        if (currentNumberOfLaps == 3)
        {
            finishSign.enabled = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Check Point"))
        {
            int checkPointNumber = other.GetComponent<checkPoint>().checkPointNumber;
            checkPopints[checkPointNumber] = true;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Start Line") && AllCheckpoints(checkPopints))
        {
            currentNumberOfLaps += 1;//incramented
            
            for (int i = 0; i < checkPopints.Length; i++)
            {
                checkPopints[i] = false;
            }
        }
    }

    private bool AllCheckpoints(bool[] checkPoints)
    {
        for(int i = 0; i < checkPoints.Length; i++)
        {
            if (checkPoints[i] == false)
            {
                return false;
            }
        }

        return true;
    }



    void AfterRace()
    {
        raceCompleteSign.enabled = true;
        Debug.Log("Starting AfterRace coroutine...");
        if (raceCompleteSign.enabled && !afterRaceComplete)
        {
            StartCoroutine(FadingToBlackCoroutine());
            afterRaceComplete = true; // Set the flag to true to indicate AfterRace has been executed
        }
    }

    IEnumerator FadingToBlackCoroutine()
    {
        yield return StartCoroutine(FadingToBlack());
        raceCompleteSign.enabled = false;
        yield return new WaitForSeconds(1);

        gameOver.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        EndOfRaceStance.SetActive(true); // Turns it on

        // Moving the position of the player character and the car...
        this.gameObject.GetComponent<DriftController>().enabled = false;
        theCarsRb.isKinematic = true;//setting it to kinematic so it doent move away from the end of race position.


        //new way for testing...
        Vector3 playerDirection = playerDisplayPosition - playerCharacter.transform.position;
        Vector3 carDirection = carDisplayPosition - playersCar.transform.position;
        Quaternion playerRotation = Quaternion.LookRotation(playerDirection);
        Quaternion carRotation = Quaternion.LookRotation(carDirection);
        playerCharacter.transform.position = playerDisplayPosition;
        playerCharacter.transform.rotation = playerRotation;
        playersCar.transform.position = carDisplayPosition;
        playersCar.transform.rotation = carRotation;


        //old way...
        //playerCharacter.transform.position = playerDisplayPosition;
        //playerCharacter.transform.rotation = Quaternion.identity;
        //playersCar.transform.position = carDisplayPosition;
        //playersCar.transform.rotation = Quaternion.identity;

        raceObjects.SetActive(false);//lets us see what we need on the canvas during the race
        afterRaceObjects.SetActive(true);//canvis ibjects only for when race is complete
        CarCamera.SetActive(false);

        StartCoroutine(FromBlackToTransparent());
    }

    IEnumerator FadingToBlack()//fading out
    {
      
        float elapsedTime = 0f;
        Color imageColour = fadingToBlackImage.color;
        //while the pre set time is greater than elapse time itll change the alpha value on the image, increasing it to black
        while (elapsedTime < timeOfFade)
        {
            elapsedTime += Time.deltaTime;
            imageColour.a = Mathf.Lerp(0f, 1f, elapsedTime / timeOfFade);
            //updating the image with the new alpha value
            fadingToBlackImage.color = imageColour;

            yield return null;
        }
       
    }

    IEnumerator FromBlackToTransparent()//fading in
    {
       
        float elapsedTime = 0f;
        Color imageColour = fadingToBlackImage.color;

        while (elapsedTime < timeOfFade)
        {
            elapsedTime += Time.deltaTime;
            //starts in reverse going from 1 for the alpha to 0 to go from black to transparent again
            imageColour.a = Mathf.Lerp(1f, 0f, elapsedTime / timeOfFade);
            fadingToBlackImage.color = imageColour;
            yield return null;
        }
       
    }



}











