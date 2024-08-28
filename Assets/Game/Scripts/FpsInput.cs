using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FpsLocker : MonoBehaviour
{

    [SerializeField] private TMP_InputField _fpsInputField;

    private int _numVal;
    private int _numFps;

    private const int DeafaultFps = 60;

    private string _str;
    private string _numericString;

    private const string DefaultFpsStr = "60";

    private void Start()
    {
        LoadFps();
    }
    public void SetFps()
    {
        _str = _fpsInputField.text;
        foreach (var c in _str)
        {
            if (c >= '0' && c <= '9')
            {
                _numericString = string.Concat(_numericString, c.ToString());
            }
        }
        _str = _numericString.TrimStart('0');
        if (string.IsNullOrEmpty(_str))
        {
            _str = DefaultFpsStr;
        }
        _numVal = System.Convert.ToInt32(_str);
        _numericString = string.Empty;
        _fpsInputField.text = _str;
        Application.targetFrameRate = _numVal;
        PlayerPrefs.SetInt("Fps", _numVal);
    }

    private void LoadFps()
    {
        _numFps = PlayerPrefs.GetInt("Fps", DeafaultFps);
        Application.targetFrameRate = _numFps;
        _fpsInputField.text = _numFps.ToString();
    }
}
