using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

public class GameEntryPoint : MonoBehaviour
{
    [SerializeField] private Settings _settings;
    [SerializeField] private FpsLocker _fpsLocker;
    private void Start()
    {
        AudioManager.Instance.SetBeginVolume();
        _settings.LoadSettings();
        _fpsLocker.StartFpsLoading();
    }
}
