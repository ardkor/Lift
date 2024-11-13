using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueDialogButton : MonoBehaviour
{
    [SerializeField] private SpeechPlayer _speechPlayer;
    [SerializeField] private EnvironmentPlayer _environmentPlayer;
    [SerializeField] private MusicPlayer _musicPlayer;

    public void TryContinueMusic()
    {
        _musicPlayer.TryContinueMusic();
    }

    public void TryContinueSpeech()
    {
        _speechPlayer.TryContinue();
    }

    public void TryContinueEnvironmentSound()
    {
        _environmentPlayer.TryContinue();
    }
}
