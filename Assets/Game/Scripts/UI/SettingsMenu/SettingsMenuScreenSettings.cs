//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Audio;
using UnityEngine.UI;
//using UnityEngine.SceneManagement;
using TMPro;

public class SettingsMenuScreenSettings : MonoBehaviour
{
    private const float _cameraStandartSize = 5f;
    private const float _cameraStandartRatio = 1920 / 1080f;
    private const int _minimalAccessibleWidth = 900;
    private const float _resolutionValueMin = 1.77f;
    private const float _resolutionValueMax = 1.78f;

    [SerializeField] private Camera _camera;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
    [SerializeField] private TMP_Text _testText;
    // [SerializeField] private TMP_Text _txt;

    private bool _isFullScreen;
    private bool _fullscreenInit;
    private Resolution[] _resolutions;
    private List<Resolution> _finalResolutions = new List<Resolution>();

    private void Start()
    {
        _resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        _resolutions = Screen.resolutions;
        // int currentResolutionIndex = 0;
        // int optionNum = -1;
        // RefreshRate maxRefreshRate = _resolutions[0].refreshRateRatio;
        Resolution prevResolution = _resolutions[0];
        string option;
        /*        for (int i = 0; i < _resolutions.Length; i++)
                {
                    if (_resolutions[i].refreshRateRatio.value > _maxRefreshRate.value)
                    {
                        _maxRefreshRate = _resolutions[i].refreshRateRatio;
                    }
                }*/
        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].width >= _minimalAccessibleWidth)
            {
                float _resInd = (float)_resolutions[i].width / (float)_resolutions[i].height;
                if (_resInd >= _resolutionValueMin && _resInd < _resolutionValueMax)
                {
                    prevResolution = _resolutions[i];
                    break;
                }
            }
        }
        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].width >= _minimalAccessibleWidth)
            {
                float _resInd = (float)_resolutions[i].width / (float)_resolutions[i].height;
                if (_resInd >= _resolutionValueMin && _resInd < _resolutionValueMax)
                {
                    if (_resolutions[i].width == prevResolution.width && _resolutions[i].height == prevResolution.height)
                    {
                        if (_resolutions[i].refreshRateRatio.value > prevResolution.refreshRateRatio.value)
                        {
                            prevResolution = _resolutions[i];
                        }
                    }
                    else
                    {
                        option = prevResolution.width + "x" + prevResolution.height + " " + ((int)prevResolution.refreshRateRatio.value) + "Hz";
                        options.Add(option);
                        _finalResolutions.Add(prevResolution);
                        prevResolution = _resolutions[i];
                    }
                }
            }
        }
        option = prevResolution.width + "x" + prevResolution.height + " " + ((int)prevResolution.refreshRateRatio.value) + "Hz";
        options.Add(option);
        _finalResolutions.Add(prevResolution);
        _resolutionDropdown.AddOptions(options);
        for (int i = 0; i < _finalResolutions.Count; i++)
        {
            if (PlayerPrefs.HasKey("ResolutionWidth"))
            {
                if (_finalResolutions[i].width == PlayerPrefs.GetInt("ResolutionWidth") && _finalResolutions[i].height == PlayerPrefs.GetInt("ResolutionHeight"))
                {
                    _resolutionDropdown.value = i;
                }
            }
            else
            {
                if (_finalResolutions[i].width == Screen.width
                        && _finalResolutions[i].height == Screen.height)
                {
                    _resolutionDropdown.value = i;
                }
            }
        }
        _resolutionDropdown.RefreshShownValue();
    }
    private void SetNativeResolution()
    {
        for (int i = 0; i < _finalResolutions.Count; i++)
        {
            if (_finalResolutions[i].width == Screen.width
                        && _finalResolutions[i].height == Screen.height)
                _resolutionDropdown.value = i;
        }
        _resolutionDropdown.RefreshShownValue();
        Screen.SetResolution(Screen.width, Screen.height, _isFullScreen);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        if (_fullscreenInit)
        {
            return;
        }
        _isFullScreen = isFullscreen;
        SetNativeResolution();
        SaveFullscreenPreference();
        SaveResolution(Screen.width, Screen.height);
    }

    private void SaveFullscreenPreference()
    {
        /* PlayerPrefs.SetInt("FullscreenPreference",
                System.Convert.ToInt32(Screen.fullScreen));*/
        PlayerPrefs.SetInt("FullscreenPreference",
               System.Convert.ToInt32(_toggle.isOn));
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = _finalResolutions[resolutionIndex];
        //_isFullScreen = false;
        //_toggle.isOn = false;
        Screen.SetResolution(resolution.width, resolution.height, _isFullScreen);
        SaveFullscreenPreference();
        SaveResolution(resolution.width, resolution.height);
        _camera.orthographicSize = _cameraStandartSize * _cameraStandartRatio / Screen.width * Screen.height;
    }

    private void SaveResolution(int resolutionWidth, int resolutionHeight)
    {
        PlayerPrefs.SetInt("ResolutionWidth", resolutionWidth);
        PlayerPrefs.SetInt("ResolutionHeight", resolutionHeight);
    }

    public void LoadSettings()
    {
        _fullscreenInit = true;
        if (PlayerPrefs.HasKey("ResolutionHeight"))
        {
            if (PlayerPrefs.HasKey("FullscreenPreference"))
            {
                if (System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference")))
                {
                    _isFullScreen = true;
                    _toggle.isOn = true;
                    SetNativeResolution();
                    _camera.orthographicSize = _cameraStandartSize * _cameraStandartRatio / Screen.width * Screen.height;
                    _fullscreenInit = false;
                    return;
                }
                else
                {
                    _isFullScreen = false;
                    Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), _isFullScreen);
                    _camera.orthographicSize = _cameraStandartSize * _cameraStandartRatio / Screen.width * Screen.height;
                    _fullscreenInit = false;
                    return;
                }

            }
        }
        _isFullScreen = true;
        _toggle.isOn = true;
        SetNativeResolution();
        _camera.orthographicSize = _cameraStandartSize * _cameraStandartRatio / Screen.width * Screen.height;
        _fullscreenInit = false;
    }
}
