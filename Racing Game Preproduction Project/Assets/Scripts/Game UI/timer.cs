using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public static bool startTimer;
    //mine


    public TextMeshProUGUI Timer;
    public float time;

    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        Timer.enabled = false;
        time = 0f;


    }

    // Update is called once per frame
    void Update()
    {

        if (startTimer)
        {
            Timer.enabled = true;
            time += Time.deltaTime;
            int seconds = ((int)time % 60);
            int minutes = ((int)time / 60);

            Timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        }
        
        if(gameOver.activeInHierarchy)
        {
            Timer.enabled = false;
            startTimer = false;
            StatTracker.SetTotalTime(time);
            StatTracker.setPlayerInfo();
        }
    }
}
