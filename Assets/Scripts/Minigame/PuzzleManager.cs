using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public TargetSlot[] slots;
    public GameObject successPanel;

    public SceneDialogueTrigger dialogueTrigger; 
    public SceneTransitionAfterDialogue sceneTransition; 

    private bool waitingForContinue = false;

    public void CheckWin()
    {
        foreach (TargetSlot slot in slots)
        {
            if (!slot.IsCorrect())
            {
                return;
            }
        }

        ShowSuccessUI();
    }

    void ShowSuccessUI()
    {
        successPanel.SetActive(true);
        waitingForContinue = true;
    }

    void Update()
    {
        if (waitingForContinue && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("dialog");

            successPanel.SetActive(false);

            dialogueTrigger.autoStart = true; 

            sceneTransition.enabled = true; 

            waitingForContinue = false;
        }
    }
}
