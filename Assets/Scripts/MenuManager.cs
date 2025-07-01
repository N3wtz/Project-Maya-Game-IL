using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject dimBG;
    public GameObject infoPanel;

    public void OpenSettingPanel()
    {
        settingPanel.SetActive(true);
        dimBG.SetActive(true);
        
    }

    public void OpenInfoPanel()
    {
        infoPanel.SetActive(true);
        dimBG.SetActive(true);
    }

    // Tutup panel Setting
    public void CloseSettingPanel()
    {
        settingPanel.SetActive(false);
        dimBG.SetActive(false);
    }

    // Tutup panel Info
    public void CloseInfoPanel()
    {
        infoPanel.SetActive(false);
        dimBG.SetActive(false);
    }

    // Mulai game (ke Level 1)
    public void StartGame()
    {
        SceneManager.LoadScene("L0 Scene 1");  // Pastikan nama scene sama persis di Build Settings
    }

    // Keluar game
    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Keluar game");  // Supaya kelihatan di editor
    }
}
