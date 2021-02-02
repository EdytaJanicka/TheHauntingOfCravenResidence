using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraHandler : MonoBehaviour
{
    public GameObject characterController1;
    public GameObject characterController2;
    public GoUpstairs upStairs;

    void Start()
    {
        characterController2.SetActive(false);
    }

    void Update()
    {
        if(upStairs.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController2.SetActive(true);
            characterController1.SetActive(false);
        }
    }
}
