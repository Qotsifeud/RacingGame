using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weight : MonoBehaviour
{
    public float rotationSpeed = 0;
    public float rotationMultiplier = 0f;
    public float movementSpeed = 1;
    public float accelerationMulitplier = 0.5f;
    public float breakMulitplier = 0f;
    public GameObject car;

    private void Update()
    {
        customisationTest _customisationScript = car.GetComponent<customisationTest>();

        _customisationScript._weightScript = this;
    }

    //scrip contain variable to apply to the movement script
}
