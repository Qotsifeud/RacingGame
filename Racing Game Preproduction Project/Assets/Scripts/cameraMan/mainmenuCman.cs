
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class mainmenuCman : MonoBehaviour
{

    public Transform playersPosition;

    private void Update()//update for cameraman movement
    {

        this.gameObject.transform.LookAt(playersPosition.transform.position);//always faces the players position

    }
}
