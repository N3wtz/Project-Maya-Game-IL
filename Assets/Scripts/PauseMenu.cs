using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject pauseMenuUI;
    public GameObject settingsPanelUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                if (settingsPanelUI.activeSelf)
                {
                    CloseSettingsPanel(); // dari Settings kembali ke Pause Menu
                }
                else
                {
                    Resume(); // dari Pause Menu kembali ke game
                }
            }
            else
            {
                Pause(); // jika game tidak pause, maka pause
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        settingsPanelUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        settingsPanelUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void OpenSettingsPanel()
    {
        pauseMenuUI.SetActive(false);
        settingsPanelUI.SetActive(true);
    }

    public void CloseSettingsPanel()
    {
        settingsPanelUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Keluar dari game...");
        Application.Quit();
    }
}
