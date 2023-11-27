using UnityEngine;

public class PointTowardsTarget : MonoBehaviour
{
    [SerializeField] private Transform targetObject;
    [SerializeField] private RectTransform arrowRectTransform;
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        if (targetObject != null && mainCamera != null)
        {
            // Get the direction vector
            Vector3 toPoint = targetObject.position - mainCamera.transform.position;

            // Project the direction vector onto the camera's plane
            Vector3 projectedDirection = Vector3.ProjectOnPlane(toPoint, mainCamera.transform.forward);

            // Get the rotation to face the projected direction
            Quaternion rotation = Quaternion.LookRotation(Vector3.forward, projectedDirection);

            // Apply the rotation to the arrow
            arrowRectTransform.rotation = rotation;
        }
    }
}
