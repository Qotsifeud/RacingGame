using UnityEngine;
using System.Collections.Generic;

public class TestSpline : MonoBehaviour
{
    [SerializeField] private List<Transform> splinePoints = new List<Transform>();
    [SerializeField] private Transform finalPath;
    
    private float interpolationValue;

    private void Update()
    {
        interpolationValue = (interpolationValue + Time.deltaTime) % 1f;
        finalPath.position = CubicLerp(splinePoints, interpolationValue);
    }





    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(ab, bc, interpolationValue);
    }





    private Vector3 CubicLerp(List<Transform> points, float t)
    {
        int numPoints = points.Count;
        int numSegments = numPoints - 3; 

        int segmentIndex = Mathf.FloorToInt(t * numSegments);
        int startIndex = Mathf.Clamp(segmentIndex, 0, numPoints - 4);
        int endIndex = Mathf.Clamp(startIndex + 3, 0, numPoints - 1);

        float segmentT = (t * numSegments) - segmentIndex;

        Vector3 a = points[startIndex].position;
        Vector3 b = points[startIndex + 1].position;
        Vector3 c = points[startIndex + 2].position;
        Vector3 d = points[endIndex].position;

        Vector3 ab_bc = QuadraticLerp(a, b, c, segmentT);
        Vector3 bc_cd = QuadraticLerp(b, c, d, segmentT);
        return Vector3.Lerp(ab_bc, bc_cd, interpolationValue);
    }
}