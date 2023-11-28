using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MiniMapCanvas : MonoBehaviour
{

    public Transform TargetObject;
    public float heightAboveTarget = 2f;
    public float yOffset = 0f;
    // Update is called once per frame
    void Update()
    {
        if (TargetObject != null)
        {
            Vector3 targetPosition = new Vector3(TargetObject.position.x, TargetObject.position.y + heightAboveTarget + yOffset, TargetObject.position.z);
            transform.position = targetPosition;
        }
        else
        {
            Debug.LogWarning("No target located");
        }
    }
}
