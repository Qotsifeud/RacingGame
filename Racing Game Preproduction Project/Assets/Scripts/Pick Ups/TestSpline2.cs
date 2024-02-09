using UnityEngine;
using System.Collections.Generic;

public class TestSpline2 : MonoBehaviour
{
    [SerializeField] private List<Transform> splinePoints = new List<Transform>();
    [SerializeField] private Transform SpeedBoostPrefab;
    private float speed = 1f;//speed for entire spline , just keep at 1 don't adjust
    public float timeBetweenSegments = 10f;//movement time between each spline, currently public for testing purposes

    private float interpolationValue;
    private float segmentTimer;

    private void Update()
    {
        interpolationValue += Time.deltaTime * speed / timeBetweenSegments;
        segmentTimer += Time.deltaTime;

        if (segmentTimer >= timeBetweenSegments)
        {
            interpolationValue = Mathf.Clamp01(interpolationValue); // clamping to keep the value between 0-1.
            segmentTimer = 0f;// resetting to 0
        }

        SpeedBoostPrefab.position = CubicLerp(splinePoints, interpolationValue);//allocating the prefab position to match the spline
    }

    private Vector3 CubicLerp(List<Transform> node, float t)
    {
        int numberOfNodes = node.Count;
        int TotalNodePerSegment = numberOfNodes - 3;

        int segmentIndex = Mathf.FloorToInt(t * TotalNodePerSegment);//figure out the total segment length of nodes
        int startIndex = Mathf.Clamp(segmentIndex, 0, numberOfNodes - 4);//break each segment into groups of 4 nodes
        int endIndex = Mathf.Clamp(startIndex + 3, 0, numberOfNodes - 1);//find the end node of each segment

        float nodeGroup = (t * TotalNodePerSegment) - segmentIndex;//inter value determined for each group of 4 nodes


        //assigning the a,b,c and d vector 3 to match the start end node and the nodes inbetween to make up the group of 4
        Vector3 a = node[startIndex].position;
        Vector3 b = node[startIndex + 1].position;
        Vector3 c = node[startIndex + 2].position;
        Vector3 d = node[endIndex].position;

        Vector3 ab_bc = QuadraticLerp(a, b, c, nodeGroup);// position/ interpolation between ab and c 
        Vector3 bc_cd = QuadraticLerp(b, c, d, nodeGroup);//interpolation between bc and d
        return Vector3.Lerp(ab_bc, bc_cd, nodeGroup);//interpolation to determine the full path
    }

    private Vector3 QuadraticLerp(Vector3 a, Vector3 b, Vector3 c, float t)
    {//linear interpolation between a-b and b-c and useing those results in the final interpolation connecting ab-bc
        Vector3 ab = Vector3.Lerp(a, b, t);
        Vector3 bc = Vector3.Lerp(b, c, t);
        return Vector3.Lerp(ab, bc, t);
    }
}//"t" represents the point along the interpolation curve and is used to smooth out the curves between all the nodes.