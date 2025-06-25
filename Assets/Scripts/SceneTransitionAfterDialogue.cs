using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionAfterDialogue : MonoBehaviour
{
    [Header("Target Dialogue")]
    public DialogueSO finalDialogueToCheck;

    [Header("Scene Transition")]
    public string sceneToLoad;
    public float delayBeforeLoad = 1f;

    private void Update()
    {
        // Mengecek apakah dialog yang sedang aktif adalah final
        if (DialogueManager.Instance != null && DialogueManager.Instance.isDialogueActive == false)
        {
            if (DialogueManager.Instance.CurrentDialogue == finalDialogueToCheck)
            {
                if (finalDialogueToCheck.IsCOnditionMet())
                {
                    StartCoroutine(LoadSceneAfterDelay());
                    enabled = false; // mencegah pemanggilan berulang
                }
            }
        }
    }

    private System.Collections.IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene(sceneToLoad);
    }
}
