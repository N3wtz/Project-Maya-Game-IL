using UnityEngine;
using UnityEngine.SceneManagement;

public class AutoLoadPauseMenu : MonoBehaviour
{
    private static bool isPauseMenuLoaded = false;

    void Awake()
    {
        if (!isPauseMenuLoaded)
        {
            SceneManager.LoadScene("PauseMenu", LoadSceneMode.Additive);
            isPauseMenuLoaded = true;
        }
    }
}
