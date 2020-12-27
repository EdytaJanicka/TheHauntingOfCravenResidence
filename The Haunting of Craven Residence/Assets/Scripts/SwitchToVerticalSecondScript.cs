using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToVerticalSecondScript : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        if (player.horizontal == true)
        {
            player.vertical = true;
            player.StartRotation2();
            player.horizontal = false;
        }
              else if (player.horizontal == false)
        {
            player.vertical = false;
            player.StartRotation();
            player.horizontal = true;
        }
 
    }

}
