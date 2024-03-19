using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapManager : MonoBehaviour
{
    public GameObject smallMiniMap;
    public GameObject largeMiniMap;
    public GameObject mediumMiniMap;

    public GameObject smallCar;
    public GameObject largeCar;
    public GameObject mediumCar;

    // Start is called before the first frame update
    void Start()
    {
        if(smallCar.activeInHierarchy)
        {
            smallMiniMap.SetActive(true);
        }
        else if(largeCar.activeInHierarchy)
        {
            largeMiniMap.SetActive(true);
        }
        else if (mediumCar.activeInHierarchy)
        {
            mediumMiniMap.SetActive(true);
        }
    }
}
