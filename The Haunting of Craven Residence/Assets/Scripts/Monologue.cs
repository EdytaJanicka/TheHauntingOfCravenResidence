using System.Collections;
using System.Collections.Generic;
using DialogueEditor;
using UnityEngine;

public class Monologue : MonoBehaviour
{
    public NPCConversation monologue;
    public bool isInAField = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ConversationManager.Instance.StartConversation(monologue);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vase")
        {
            ConversationManager.Instance.StartConversation(monologue);
            isInAField = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Vase")
        {
            isInAField = false;
        }
    }
}
