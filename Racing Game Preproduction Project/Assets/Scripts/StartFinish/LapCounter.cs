using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LapCounter : MonoBehaviour
{
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
