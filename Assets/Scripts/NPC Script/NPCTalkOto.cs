using System.Collections.Generic;
using UnityEngine;

public class NPCTalkOto : MonoBehaviour
{
    public List<DialogueSO> conversations;
    public DialogueSO currentConversation;
    private bool hasTriggered = false; // Supaya hanya jalan sekali

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasTriggered) return; // Supaya tidak jalan 2x
        if (other.CompareTag("Player"))
        {
            CheckForNewConversation();
            if (currentConversation != null)
            {
                DialogueManager.Instance.StartDialogue(currentConversation);
                hasTriggered = true;
            }
        }
    }

    private void CheckForNewConversation()
    {
        for (int i = 0; i < conversations.Count; i++)
        {
            var convo = conversations[i];
            if (convo != null && convo.IsCOnditionMet())
            {
                currentConversation = convo;
                conversations.RemoveAt(i);
                break;
            }
        }
    }
}
