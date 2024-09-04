//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using TMPro;

public class Settings : MonoBehaviour
{
    private Resolution[] _resolutions;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_Text _txt;

    private bool fullScreen;
    // public Dropdown qualityDropdown;
    List<Resolution> resolutions = new List<Resolution>();
    void Start()
    {
        _resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        _resolutions = Screen.resolutions;
       // int currentResolutionIndex = 0;
       // int optionNum = -1;
        RefreshRate _maxRefreshRate = _resolutions[0].refreshRateRatio;

        for (int i = 0; i<_resolutions.Length; i++)
        {
            if (_resolutions[i].refreshRateRatio.value > _maxRefreshRate.value)
            {
                _maxRefreshRate = _resolutions[i].refreshRateRatio;
            }
        }

        for (int i = 0; i < _resolutions.Length; i++)
        {

            if (_resolutions[i].refreshRateRatio.value >= _maxRefreshRate.value - 5)
            {
                string option = _resolutions[i].width + "x" + _resolutions[i].height + " " + _resolutions[i].refreshRateRatio + "Hz";
                options.Add(option);
                resolutions.Add(_resolutions[i]);

            }
        }
        _resolutionDropdown.AddOptions(options);
        for (int i = 0; i < resolutions.Count; i++){
            if (PlayerPrefs.HasKey("ResolutionWidth"))
            {
                if (resolutions[i].width == PlayerPrefs.GetInt("ResolutionWidth"))
                {
                    _txt.text = i.ToString();
                    _resolutionDropdown.value = i;
                }
            }
            else
            {
                if (resolutions[i].width == Screen.width
                        && resolutions[i].height == Screen.height)
                    _resolutionDropdown.value = i;
            }
        }

        
        _resolutionDropdown.RefreshShownValue();
        LoadSettings();
         //Screen.width.ToString();
    }
    private void SetNativeResolution()
    {
        fullScreen = true;
        _toggle.isOn = true;
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (resolutions[i].width == Screen.width
                        && resolutions[i].height == Screen.height)
                _resolutionDropdown.value = i;
        }
        _resolutionDropdown.RefreshShownValue();
        Screen.SetResolution(Screen.width, Screen.height, fullScreen);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        //Debug.Log(Screen.fullScreen);
        //Screen.fullScreen = isFullscreen;
        fullScreen = isFullscreen;
        Resolution resolution = Screen.currentResolution;
        if (isFullscreen)
        {
            SetNativeResolution();
        }
        else
        {
           // FullScreenMode fullScreenMode = fullScreen;
            Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
            //Screen.SetResolution(1280, 920, FullScreenMode.Windowed);
        }
        SaveFullscreenPreference();
        SaveResolution(Screen.width, Screen.height);
    }

    private void SaveFullscreenPreference()
    {
        PlayerPrefs.SetInt("FullscreenPreference",
               System.Convert.ToInt32(Screen.fullScreen));
    }

    public void SetResolution(int resolutionIndex) //??
    {
        Resolution resolution = resolutions[resolutionIndex];
        fullScreen = false;
        _toggle.isOn = false;
        Screen.SetResolution(resolution.width, resolution.height, FullScreenMode.Windowed);
        SaveFullscreenPreference();
        SaveResolution(resolution.width, resolution.height);
    }
 
    private void SaveResolution(int resolutionWidth, int resolutionHeight)
    {
        PlayerPrefs.SetInt("ResolutionWidth", resolutionWidth);
        PlayerPrefs.SetInt("ResolutionHeight", resolutionHeight);
    }



    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("ResolutionHeight"))
        {
            if (PlayerPrefs.HasKey("FullscreenPreference"))
            {
                if (System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference")))
                {
                    SetNativeResolution();
                }
                else
                {
                    fullScreen = false;
                    Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), FullScreenMode.Windowed);
                    _toggle.isOn = false;
                    return;
                }

            }
        }
        SetNativeResolution();
    }
}
