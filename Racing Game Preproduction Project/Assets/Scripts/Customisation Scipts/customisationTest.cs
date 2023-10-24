using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class customisationTest : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject spoiler;
    bool spoilerOn = true;
    private carMovement _moveSript;

    //Start is called before the first frame update
    void Start()
    {
       _moveSript = car.GetComponent<carMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("c")) 
        {
            spoilerOn = !spoilerOn;
            spoiler.SetActive(spoilerOn);
        }

        if (spoiler.activeInHierarchy) 
        {
            _moveSript.rotationRight = new Vector3(0, 60, 0);
            _moveSript.rotationLeft = new Vector3(0, -60, 0);
        }
        else 
        {
            _moveSript.rotationRight = new Vector3(0, 30, 0);
            _moveSript.rotationLeft = new Vector3(0, -30, 0);
        }
    }
}
