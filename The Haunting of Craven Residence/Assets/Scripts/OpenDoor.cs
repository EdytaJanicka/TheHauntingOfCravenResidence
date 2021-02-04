using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator door1;
    public Animator door2;
    public GameObject key;
    public GameObject EButton;
    public GameObject door;
    public bool isInField = false;

    private void Start()
    {
        EButton.SetActive(false);
        key.SetActive(false);


    }

    private void Update()
    {
        if(isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            key.SetActive(true);
            door1.SetTrigger("Open");
            door2.SetTrigger("Open");
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
