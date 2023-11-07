using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spoiler : MonoBehaviour
{
    public float rotationSpeed = 60;
    public float rotationMultiplier = 2f;
    public float movementSpeed = 0;
    public float accelerationMulitplier = 0f;
    public float breakMulitplier = 0f;
    public GameObject car;

    private void Update()
    {
        customisationTest _customisationScript = car.GetComponent<customisationTest>();

        _customisationScript._spoilerScript = this;
    }

    //scrip contain variable to apply to the movement script

}
