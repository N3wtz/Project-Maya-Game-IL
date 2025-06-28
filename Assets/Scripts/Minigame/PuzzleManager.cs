using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public TargetSlot[] slots;
    public GameObject successPanel;

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
    }
}
