using UnityEngine;

[CreateAssetMenu(fileName = "DialogueSO", menuName ="Dialogue/DialogueNode")]
public class DialogueSO : ScriptableObject
{
    public DialogueLine[] lines;
    public DialogueOption[] options;

    [Header("Conditional Requirements")]
    public ActorSO[] requiredNPCs;

    public bool requirePuzzleCompleted;  // tambah ini

    public bool IsCOnditionMet()
    {
        // Cek NPC dulu
        if (requiredNPCs.Length > 0)
        {
            foreach (var npc in requiredNPCs)
            {
                if (!DialogueHistoryTracker.Instance.HasSpokenWith(npc))
                    return false;
            }
        }

        // Cek puzzle
        if (requirePuzzleCompleted)
        {
            if (GameState.Instance == null || !GameState.Instance.puzzleCompleted)
                return false;
        }

        return true;
    }
}

[System.Serializable]
public class DialogueLine
{
    public ActorSO speaker;
    [TextArea(3,5)] public string text;
}

[System.Serializable]
public class DialogueOption
{
    public string optionText;
    public DialogueSO nextDialogue;
}
