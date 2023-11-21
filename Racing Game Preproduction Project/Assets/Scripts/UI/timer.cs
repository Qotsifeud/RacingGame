using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class timer : MonoBehaviour
{
    public TextMeshProUGUI Timer;
    float time = 300f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        int seconds = ((int)time % 60);
        int minutes = ((int)time / 60);

        Timer.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }
}
