using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class Monologue : MonoBehaviour
{
    public NPCConversation monologue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Vase")
        {
            ConversationManager.Instance.StartConversation(monologue);
        }
    }
}
