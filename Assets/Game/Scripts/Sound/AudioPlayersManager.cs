using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayersManager : MonoBehaviour
{
    private SpeechPlayer _speechPlayer;
    private EnvironmentPlayer _environmentPlayer;
    private MusicPlayer _musicPlayer;
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
