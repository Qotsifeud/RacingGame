using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class customisationTest : MonoBehaviour
{
    [SerializeField] GameObject car;
    [SerializeField] GameObject wings;
    [SerializeField] GameObject spoiler;

    //private carMovement _moveSript;

    // Start is called before the first frame update
    void Start()
    {
       // _moveSript = car.GetComponent<carMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(wings.activeInHierarchy) 
        {
            
        }

        if (spoiler.activeInHierarchy) 
        {

        }
    }
}
