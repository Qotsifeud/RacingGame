using UnityEngine;

public class AIArrowHead : MonoBehaviour
{//just to make it face the players car at all times so they can easily see the arrow
    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Face the player
            transform.LookAt(player.transform);
        }
        else
        {
            
        }
    }
}
