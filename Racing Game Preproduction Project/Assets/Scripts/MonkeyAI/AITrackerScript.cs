using UnityEngine;

public class ATTrackerScript : MonoBehaviour
{
    public Transform PlayerCar;
    public Transform MonkeyAI;
    public RectTransform ArrowTransform;
    public Camera mainCamera;

    private void Update()
    {
        if (PlayerCar != null && MonkeyAI != null && mainCamera != null)
        {
            // Check if the target is in the camera's view
            if (IsTargetInView())
            {
                ArrowTransform.gameObject.SetActive(false);
            }
            else
            {
                ArrowTransform.gameObject.SetActive(true);

                // Calculate the direction vector from player to target
                Vector3 toTarget = MonkeyAI.position - PlayerCar.position;

                // Project the direction vector onto the camera's plane
                Vector3 projectedDirection = Vector3.ProjectOnPlane(toTarget, mainCamera.transform.forward);

                // Calculate the angle between the projected direction and the forward vector
                float angle = Vector3.SignedAngle(mainCamera.transform.forward, projectedDirection, Vector3.up);

                // Rotate the compass RectTransform to point towards the target
                ArrowTransform.localEulerAngles = new Vector3(0, 0, angle);
            }
        }
    }

    private bool IsTargetInView()
    {
        Vector3 targetViewportPos = mainCamera.WorldToViewportPoint(MonkeyAI.position);
        return targetViewportPos.x > 0 && targetViewportPos.x < 1 && targetViewportPos.y > 0 && targetViewportPos.y < 1 && targetViewportPos.z > 0;
    }
}
