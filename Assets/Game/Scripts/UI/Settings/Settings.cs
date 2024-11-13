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
    [SerializeField] private Camera _camera;
    private const float _cameraStandartSize = 5f;
    private const float _cameraStandartRatio = 1920/1080f;
    [SerializeField] private Toggle _toggle;
    [SerializeField] private TMP_Dropdown _resolutionDropdown;
   // [SerializeField] private TMP_Text _txt;
    private const int minimalWidth = 960;
    private bool fullScreen;
    List<Resolution> resolutions = new List<Resolution>();
    void Start()
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
            if (_resolutions[i].width >= minimalWidth)
            {
                prevResolution = _resolutions[i];
                break;
            }
        }
        for (int i = 0; i < _resolutions.Length; i++)
        {
            if (_resolutions[i].width >= minimalWidth)
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
                    resolutions.Add(prevResolution);
                    prevResolution = _resolutions[i];
                }
            }
        }
        option = prevResolution.width + "x" + prevResolution.height + " " + ((int)prevResolution.refreshRateRatio.value) + "Hz";
        options.Add(option);
        resolutions.Add(prevResolution);
        _resolutionDropdown.AddOptions(options);
        for (int i = 0; i < resolutions.Count; i++)
        {
            if (PlayerPrefs.HasKey("ResolutionWidth"))
            {
                if (resolutions[i].width == PlayerPrefs.GetInt("ResolutionWidth"))
                {
                    //_txt.text = PlayerPrefs.GetInt("ResolutionWidth").ToString();
                     _resolutionDropdown.value = i;
                }
            }
            else
            {
                if (resolutions[i].width == Screen.width
                        && resolutions[i].height == Screen.height)
                {
                    //_txt.text = Screen.width.ToString();
                    _resolutionDropdown.value = i;

                }
            }
        }

        
        _resolutionDropdown.RefreshShownValue();
        //LoadSettings(); #
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
       // _txt.text = Screen.width.ToString();
        Screen.SetResolution(Screen.width, Screen.height, fullScreen);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        //Debug.Log(Screen.fullScreen);
        //Screen.fullScreen = isFullscreen;
        fullScreen = isFullscreen;
        //Resolution resolution = Screen.currentResolution;
        //_txt.text = Screen.currentResolution.ToString();
        if (isFullscreen)
        {
            SetNativeResolution();
        }
        else
        {
           // FullScreenMode fullScreenMode = fullScreen;
            Screen.SetResolution(Screen.width, Screen.height, fullScreen);
            //Screen.SetResolution(resolution.width, resolution.height, fullScreen);
            //Screen.SetResolution(1280, 920, FullScreenMode.ExclusiveFullScreen);
        }
        SaveFullscreenPreference();
        SaveResolution(Screen.width, Screen.height);
    }

    private void SaveFullscreenPreference()
    {
        PlayerPrefs.SetInt("FullscreenPreference",
               System.Convert.ToInt32(Screen.fullScreen));
    }

    public void SetResolution(int resolutionIndex) 
    {
        Resolution resolution = resolutions[resolutionIndex];
        fullScreen = false;
        _toggle.isOn = false;
        Screen.SetResolution(resolution.width, resolution.height, fullScreen);
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
        if (PlayerPrefs.HasKey("ResolutionHeight"))
        {
            if (PlayerPrefs.HasKey("FullscreenPreference"))
            {
                if (System.Convert.ToBoolean(PlayerPrefs.GetInt("FullscreenPreference")))
                {
                    SetNativeResolution();
                    _camera.orthographicSize = _cameraStandartSize * _cameraStandartRatio / Screen.width * Screen.height;
                    return;
                }
                else
                {
                    fullScreen = false;
                    Screen.SetResolution(PlayerPrefs.GetInt("ResolutionWidth"), PlayerPrefs.GetInt("ResolutionHeight"), fullScreen);
                    _toggle.isOn = false;
                    _camera.orthographicSize = _cameraStandartSize * _cameraStandartRatio / Screen.width * Screen.height;
                    return;
                }

            }
        }
        SetNativeResolution();
        _camera.orthographicSize = _cameraStandartSize * _cameraStandartRatio / Screen.width * Screen.height;
    }
}
