using System.Collections.Generic;
using UnityEngine;
using TMPro; // GANTI dari UnityEngine.UI ke TMPro
using UnityEngine.UI;

public class DisplaySettings : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown; // GANTI ke TMP_Dropdown
    public Toggle fullscreenToggle;

    Resolution[] resolutions;

    void Start()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        int currentResIndex = 0;
        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResIndex;
        resolutionDropdown.RefreshShownValue();

        fullscreenToggle.isOn = Screen.fullScreen;
    }

    public void ApplySettings()
    {
        Resolution res = resolutions[resolutionDropdown.value];
        Screen.SetResolution(res.width, res.height, fullscreenToggle.isOn);
    }
}
