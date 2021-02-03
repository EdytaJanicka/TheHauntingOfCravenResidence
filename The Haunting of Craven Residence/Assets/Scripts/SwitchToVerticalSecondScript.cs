using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToVerticalSecondScript : MonoBehaviour
{
    public PlayerController player;

    private void OnTriggerEnter(Collider other)
    {
            Invoke("ChangePosition2", 0.01f);
    }

    private void ChangePosition2()
    {

        if (player.horizontal == true)
        {
            Debug.Log("MIau");
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
