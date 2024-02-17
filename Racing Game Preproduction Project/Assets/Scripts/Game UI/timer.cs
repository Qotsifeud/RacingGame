using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    public float time = 0f;

    public GameObject gameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        int seconds = ((int)time % 60);
        int minutes = ((int)time / 60);

        Timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);

        //if(time <= 0) 
        //{
        //    gameOver.SetActive(true);
        //    Cursor.lockState = CursorLockMode.None;
        //    Cursor.visible = true;
        //}
    }
}
