using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraHandler : MonoBehaviour
{
    public GameObject characterController1;
    public GameObject characterController2;

    public Camera firstFlashback;
    public Camera secondFlashback;
    public Camera thirdFlashback;
    public Camera fourthFlashback;
    public Camera fifthFlashback;

    public GoUpstairs upStairs;
    public GoDownstairs downStairs;
    public LightEffectOnObjects vase;
    public LightEffectOnObjects brooch;
    public LightEffectOnObjects sweep;
    public LightEffectOnObjects pearls;
    public LightEffectOnObjects bible;
    public GameObject wallHack;



    void Start()
    {
        characterController2.SetActive(false);
        firstFlashback.enabled = false;
        secondFlashback.enabled = false;
        thirdFlashback.enabled = false;
        fourthFlashback.enabled = false;
        fifthFlashback.enabled = false;
    }

    void Update()
    {
        if(upStairs.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController2.SetActive(true);
            characterController1.SetActive(false);
            upStairs.isInField = false;
            wallHack.SetActive(false);
        }


        if (downStairs.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController2.SetActive(false);
            characterController1.SetActive(true);
            downStairs.isInField = false;
            wallHack.SetActive(true);

        }

        if (vase.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController1.SetActive(false);
            firstFlashback.enabled = true;
            vase.isInField = false;
            vase.EButton.SetActive(false);
            Invoke("DisableFirstFlashback", 2f);
        }

        if (brooch.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController1.SetActive(false);
            secondFlashback.enabled = true;
            brooch.isInField = false;
            brooch.EButton.SetActive(false);
            Invoke("DisableSecondFlashback", 2f);
        }

        if (sweep.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController1.SetActive(false);
            thirdFlashback.enabled = true;
            sweep.isInField = false;
            sweep.EButton.SetActive(false);
            Invoke("DisableThirdFlashback", 2f);
        }

        if (pearls.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController2.SetActive(false);
            fourthFlashback.enabled = true;
            pearls.isInField = false;
            pearls.EButton.SetActive(false);
            Invoke("DisableFourthFlashback", 2f);
        }

        if (bible.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController2.SetActive(false);
            fifthFlashback.enabled = true;
            bible.isInField = false;
            bible.EButton.SetActive(false);
            Invoke("DisableFifthFlashback", 2f);
        }

    }

    private void DisableFirstFlashback()
    {
        characterController1.SetActive(true);
        firstFlashback.enabled = false;
        vase.GetComponent<SphereCollider>().enabled = false;
        vase.Fade();
    }

    private void DisableSecondFlashback()
    {
        characterController1.SetActive(true);
        secondFlashback.enabled = false;
        brooch.GetComponent<SphereCollider>().enabled = false;
        brooch.Fade();
    }

    private void DisableThirdFlashback()
    {
        characterController1.SetActive(true);
        thirdFlashback.enabled = false;
        sweep.GetComponent<SphereCollider>().enabled = false;
        sweep.Fade();
    }

    private void DisableFourthFlashback()
    {
        characterController2.SetActive(true);
        fourthFlashback.enabled = false;
        pearls.GetComponent<SphereCollider>().enabled = false;
        pearls.Fade();
    }

    private void DisableFifthFlashback()
    {
        characterController2.SetActive(true);
        fifthFlashback.enabled = false;
        bible.GetComponent<SphereCollider>().enabled = false;
        bible.Fade();
    }

}
