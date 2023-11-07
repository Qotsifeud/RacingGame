using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class breaks : MonoBehaviour
{
    public float rotationSpeed = 0;
    public float rotationMultiplier = 0f;
    public float movementSpeed = 0;
    public float accelerationMulitplier = 0f;
    public float breakMulitplier = 1f;
    public GameObject car;

    private void Update()
    {
        customisationTest _customisationScript = car.GetComponent<customisationTest>();

        _customisationScript._breakScript = this;
    }

    //scrip contain variable to apply to the movement script

}
