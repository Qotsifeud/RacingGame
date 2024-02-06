using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PointsUI : MonoBehaviour
{
    private TextMeshProUGUI pointsText;


    void Start()
    {
        pointsText = GetComponent<TextMeshProUGUI>();
    }
    
    public void UpdatePointsText(PointCollectionTest pointCollectionTest)
    {
        pointsText.text = pointCollectionTest.NumberOfPoints.ToString();
    }

}
