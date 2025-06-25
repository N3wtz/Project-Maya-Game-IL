using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneDialogueTrigger : MonoBehaviour
{
    [Header("Dialogue Settings")]
    public List<DialogueSO> conversations;
    public DialogueSO currentConversation;

    [Header("Start Settings")]
    [Tooltip("Mulai otomatis saat start scene")]
    public bool autoStart = true;

    [Tooltip("Waktu jeda sebelum dialog muncul (dalam detik) jika autoStart aktif")]
    public float startDelay = 1.7f;

    private bool hasStarted = false;

    private void Start()
    {
        if (autoStart)
        {
            StartCoroutine(SimulateFirstSpacePress());
        }
    }

    private void Update()
    {
        if (!autoStart && Input.GetKeyDown(KeyCode.Space))
        {
            HandleDialogueTrigger();
        }
        else if (autoStart && Input.GetKeyDown(KeyCode.Space) && hasStarted)
        {
            DialogueManager.Instance.AdvanceDialogue();
        }
    }

    private IEnumerator SimulateFirstSpacePress()
    {
        yield return new WaitForSeconds(startDelay);

        // Tunggu sampai DialogueManager.Instance tersedia
        while (DialogueManager.Instance == null)
        {
            yield return null;
        }

        HandleDialogueTrigger(); // Tekan otomatis di awal
    }

    private void HandleDialogueTrigger()
    {
        if (DialogueManager.Instance == null) return;

        if (DialogueManager.Instance.isDialogueActive)
        {
            DialogueManager.Instance.AdvanceDialogue();
        }
        else if (!hasStarted)
        {
            CheckForNewConversation();
            if (currentConversation != null)
            {
                DialogueManager.Instance.StartDialogue(currentConversation);
                hasStarted = true;
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
                conversations.RemoveAt(i);
                currentConversation = convo;
                break;
            }
        }
    }
}
