using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public TargetSlot[] slots;
    public GameObject successPanel;
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
        GameState.Instance.puzzleCompleted = true; 
        waitingForContinue = true;
    }

    void Update()
    {
        if (waitingForContinue && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Spasi ditekan, menutup successPanel");
            successPanel.SetActive(false); 
            waitingForContinue = false;
        }
    }
}
