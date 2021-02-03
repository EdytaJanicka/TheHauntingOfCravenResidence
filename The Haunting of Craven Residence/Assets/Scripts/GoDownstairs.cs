using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDownstairs : MonoBehaviour
{
    public GameObject EButton;
    public bool isInField = false;

    void Start()
    {
        EButton.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

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
