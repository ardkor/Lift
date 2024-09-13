using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameButton : MonoBehaviour
{
    [SerializeField] private SpeechPlayer _speechPlayer;
    [SerializeField] private MusicPlayer _musicPlayer;

    public void TryPauseMusic()
    {
        _musicPlayer.TryPauseMusic();
    }
   
    public void TryPauseSpeech()
    {
        _speechPlayer.TryPauseSpeech();
    }
}
