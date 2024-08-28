//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;
//using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour
{
    private Resolution[] _resolutions;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    // public Dropdown qualityDropdown;

    void Start()
    {
        _resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        _resolutions = Screen.resolutions;
        int currentResolutionIndex = 0;

        for (int i = 0; i < _resolutions.Length; i++)
        {
            string option = _resolutions[i].width + "x" + _resolutions[i].height + " " + _resolutions[i].refreshRateRatio + "Hz";
            options.Add(option);
            if (_resolutions[i].width == Screen.currentResolution.width
                  && _resolutions[i].height == Screen.currentResolution.height)
                currentResolutionIndex = i;
        }

        _resolutionDropdown.AddOptions(options);
        _resolutionDropdown.RefreshShownValue();
        LoadSettings(currentResolutionIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        //Screen.fullScreen = isFullscreen;
        if (isFullscreen)
        {
            Resolution resolution = Screen.currentResolution;
            Screen.SetResolution(resolution.width,
                      resolution.height, FullScreenMode.ExclusiveFullScreen); // FullScreenMode.FullScreenWindow);
            _resolutionDropdown.RefreshShownValue();
        }
        else
        {
           // FullScreenMode fullScreenMode = FullScreenMode.FullScreenWindow;
            Screen.SetResolution(1280, 920, FullScreenMode.Windowed);
        }
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,
                  resolution.height, FullScreenMode.ExclusiveFullScreen);
    }


    /*    public void SetQuality(int qualityIndex)
        {

            QualitySettings.SetQualityLevel(qualityIndex);

        }*/

    public void ExitSettings()
    {
        SceneManager.LoadScene("Level");
    }

    public void SaveSettings()
    {
/*        PlayerPrefs.SetInt("QualitySettingPreference",
                   qualityDropdown.value);*/
        PlayerPrefs.SetInt("ResolutionPreference",
                   _resolutionDropdown.value);
        PlayerPrefs.SetInt("FullscreenPreference",
                   System.Convert.ToInt32(Screen.fullScreen));
    }

    public void LoadSettings(int currentResolutionIndex)
    {
/*        if (PlayerPrefs.HasKey("QualitySettingPreference"))
            qualityDropdown.value =
                         PlayerPrefs.GetInt("QualitySettingPreference");
        else
            qualityDropdown.value = 3;*/
        if (PlayerPrefs.HasKey("ResolutionPreference"))
            _resolutionDropdown.value =
                         PlayerPrefs.GetInt("ResolutionPreference");
        else
            _resolutionDropdown.value = currentResolutionIndex;
        if (PlayerPrefs.HasKey("FullscreenPreference"))
            Screen.fullScreen =
            System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference"));
        else
            Screen.fullScreen = true;
        /*if (PlayerPrefs.HasKey("VolumePreference"))
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");
        else
            volumeSlider.value =
                        PlayerPrefs.GetFloat("VolumePreference");*/
    }
}
