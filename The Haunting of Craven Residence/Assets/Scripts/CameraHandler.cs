using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;



public class CameraHandler : MonoBehaviour
{
    public NPCConversation monologue;
    public NPCConversation monologue1;
    public NPCConversation monologue2;
    public NPCConversation monologue3;
    public NPCConversation monologue4;
    public NPCConversation monologue5;
    public NPCConversation monologue6;


    public GameObject characterController1;
    public GameObject characterController2;

    public Camera firstFlashback;
    public Camera secondFlashback;
    public Camera thirdFlashback;
    public Camera fourthFlashback;
    public Camera fifthFlashback;
    public Camera sixthFlashback;
    public Camera seventhFlashback;

    private int story = 0;


    public GoUpstairs upStairs;
    public GoDownstairs downStairs;
    public LightEffectOnObjects vase;
    public LightEffectOnObjects brooch;
    public LightEffectOnObjects sweep;
    public LightEffectOnObjects pearls;
    public LightEffectOnObjects bible;
    public LightEffectOnObjects sabre;

    public Animator kiss1;
    public Animator kiss2;
    public Animator kiss3;
    public Animator kiss4;

    public GameObject wallHack;
    public GameObject wallHack1;

    public bool haveKnob = false;
    public GameObject Knob;

    void Start()
    {
        characterController2.SetActive(false);
        firstFlashback.enabled = false;
        secondFlashback.enabled = false;
        thirdFlashback.enabled = false;
        fourthFlashback.enabled = false;
        fifthFlashback.enabled = false;
        sixthFlashback.enabled = false;
        seventhFlashback.enabled = false;
        wallHack1.SetActive(false);
        Knob.SetActive(false);
    }

    void Update()
    {
        if(upStairs.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController2.SetActive(true);
            characterController1.SetActive(false);
            upStairs.isInField = false;
            wallHack.SetActive(false);
            wallHack1.SetActive(true);

        }


        if (downStairs.isInField == true && Input.GetKeyDown(KeyCode.E))
        {
            characterController2.SetActive(false);
            characterController1.SetActive(true);
            downStairs.isInField = false;
            wallHack.SetActive(true);
            wallHack1.SetActive(false);


        }

        if (vase.isInField == true && Input.GetKeyDown(KeyCode.E) && story == 0)
        {
            characterController1.SetActive(false);
            firstFlashback.enabled = true;
            vase.isInField = false;
            vase.EButton.SetActive(false);
            ConversationManager.Instance.StartConversation(monologue);
            Invoke("DisableFirstFlashback", 18f);
            story++;
        }

        if (brooch.isInField == true && Input.GetKeyDown(KeyCode.E) && story == 1)
        {
            characterController1.SetActive(false);
            secondFlashback.enabled = true;
            brooch.isInField = false;
            brooch.EButton.SetActive(false);
            ConversationManager.Instance.StartConversation(monologue1);
            Invoke("DisableSecondFlashback", 18f);
            story++;
            kiss1.SetTrigger("Play");

        }

        if (sweep.isInField == true && Input.GetKeyDown(KeyCode.E) && story == 2)
        {
            characterController1.SetActive(false);
            thirdFlashback.enabled = true;
            sweep.isInField = false;
            ConversationManager.Instance.StartConversation(monologue2);
            sweep.EButton.SetActive(false);
            Invoke("DisableThirdFlashback", 20f);
            story++;
            kiss2.SetTrigger("Play");


        }

        if (pearls.isInField == true && Input.GetKeyDown(KeyCode.E) && story == 3)
        {
            characterController2.SetActive(false);
            fourthFlashback.enabled = true;
            pearls.isInField = false;
            pearls.EButton.SetActive(false);
            ConversationManager.Instance.StartConversation(monologue3);
            Invoke("DisableFourthFlashback", 20f);
            story++;
            kiss3.SetTrigger("Play");
            kiss4.SetTrigger("Play");

        }

        if (bible.isInField == true && Input.GetKeyDown(KeyCode.E) && story == 4)
        {
            characterController2.SetActive(false);
            fifthFlashback.enabled = true;
            bible.isInField = false;
            ConversationManager.Instance.StartConversation(monologue4);
            bible.EButton.SetActive(false);
            Invoke("DisableFifthFlashback", 22f);
            story++;
            haveKnob = true;
            Knob.SetActive(true);

        }

        if (sabre.isInField == true && Input.GetKeyDown(KeyCode.E) && story == 5)
        {
            characterController2.SetActive(false);
            sixthFlashback.enabled = true;
            ConversationManager.Instance.StartConversation(monologue5);
            sabre.isInField = false;
            sabre.EButton.SetActive(false);
            Invoke("DisableSixthFlashback", 20f);
            story++;
            EnableSeventhFlashback();
        }

        if (vase.isInField == true && Input.GetKeyDown(KeyCode.E) && story == 6)
        {
            characterController1.SetActive(false);
            seventhFlashback.enabled = true;
            vase.isInField = false;
            vase.EButton.SetActive(false);
            ConversationManager.Instance.StartConversation(monologue6);
            Invoke("DisableFirstFlashback", 8f);
            story++;
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

    private void DisableSixthFlashback()
    {
        characterController2.SetActive(true);
        sixthFlashback.enabled = false;
        sabre.GetComponent<SphereCollider>().enabled = false;
        sabre.Fade();
    }

    private void EnableSeventhFlashback()
    {
        vase.GetComponent<SphereCollider>().enabled = true;
    }

}
