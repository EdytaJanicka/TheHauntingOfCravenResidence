using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleWallVisibility : MonoBehaviour
{
    public PlayerController visibilityBool;
    public GameObject[] walls1;
    public GameObject[] walls2;
    void Start()
    {
         walls1 = GameObject.FindGameObjectsWithTag("Wall1");
         walls2 = GameObject.FindGameObjectsWithTag("Wall2");
    }

    private void Update()
    {
        if(visibilityBool.horizontal == true)
        {
            foreach (GameObject Wall in walls1)
             {
            Wall.GetComponent<MeshRenderer>().enabled = false;
             }
            foreach (GameObject Wall in walls2)
            {
                Wall.GetComponent<MeshRenderer>().enabled = true;
            }

        }else if(visibilityBool.vertical == true)
        {
            foreach (GameObject Wall in walls2)
            {
                Wall.GetComponent<MeshRenderer>().enabled = false;
            }
            foreach (GameObject Wall in walls1)
            {
                Wall.GetComponent<MeshRenderer>().enabled = true;
            }
        }
    }
}
