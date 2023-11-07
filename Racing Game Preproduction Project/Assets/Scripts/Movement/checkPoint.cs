using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPoint : MonoBehaviour
{
    carMovement _carScript;

    // Update is called once per frame
    void OnCollisionEnter(Collision Col)
    {
        GameObject car = Col.gameObject;

        if(car.tag == "Player")
        {
            _carScript = car.GetComponent<carMovement>();
            _carScript.respawnPoint = gameObject;
        }
    }
}
