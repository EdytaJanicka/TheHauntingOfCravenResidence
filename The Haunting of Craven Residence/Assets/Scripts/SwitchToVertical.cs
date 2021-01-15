using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToVertical : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
        Invoke("ChangePosition1", 0.05f) ;

    }

    private void ChangePosition1()
    {
        if (player.horizontal == false)
        {
            player.vertical = false;
            player.StartRotation2();
            player.horizontal = true;
        }
        else if (player.horizontal == true)
        {
            player.vertical = true;
            player.StartRotation();
            player.horizontal = false;
        }
    }


}