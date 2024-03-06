using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
    public GameObject EndOfRaceStance;//this appears at the end of each race
    public GameObject playerDisplaySpot;
    public GameObject carDisplaySpot;
    public GameObject playerCharacter;
    public GameObject playersCar;
    private Vector3 playerDisplayPosition;
    private Vector3 carDisplayPosition;
    //the above variables ar for the winning game over screen at the end of each race



    public TextMeshProUGUI lapCounter;
    public TextMeshProUGUI startSign;
    public TextMeshProUGUI finishSign;
    public GameObject gameOver;

    public int currentNumberOfLaps = 1;
    public int maxLaps = 3;

    public bool[] checkPopints = new bool[5];
    

   public void Start()
    {
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

        if (currentNumberOfLaps > maxLaps)
        {
            //end game
            //Debug.Log("i finished the laps");

            gameOver.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            EndOfRaceStance.SetActive(true);//turns it on

            //moving the position of the player character and the car...

            this.gameObject.GetComponent<DriftController>().enabled = false;
            playerCharacter.transform.position = playerDisplayPosition;
            playerCharacter.transform.rotation = Quaternion.identity;
            playersCar.transform.position = carDisplayPosition;
            playersCar.transform.rotation = Quaternion.identity;





        }

        if(currentNumberOfLaps == 1)
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
}
