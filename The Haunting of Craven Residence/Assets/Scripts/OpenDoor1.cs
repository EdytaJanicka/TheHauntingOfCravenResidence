using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor1 : MonoBehaviour
{
    public Animator door1;
    public GameObject EButton;
    public GameObject door;
    public bool isInField = false;
    public CameraHandler hand;

    private void Start()
    {
        EButton.SetActive(false);

    }

    private void Update()
    {
        if (isInField == true && Input.GetKeyDown(KeyCode.E) && hand.haveKnob == true)
        {
            door1.SetTrigger("Open");
            door.GetComponent<BoxCollider>().enabled = false;
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        EButton.SetActive(true);
        isInField = true;


    }

    private void OnTriggerExit(Collider other)
    {

        EButton.SetActive(false);
        isInField = false;

    }
}
