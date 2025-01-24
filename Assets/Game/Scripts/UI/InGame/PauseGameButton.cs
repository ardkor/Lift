using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameButton : MonoBehaviour, Pressable
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private SpeechPlayer _speechPlayer;
    [SerializeField] private EnvironmentPlayer _environmentPlayer;
    [SerializeField] private MusicPlayer _musicPlayer;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Collider2D _pauseCollider;

    private UIManager _uiManager;
    private bool _activeness = true;

    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
    }

    private void OnMouseDown()
    {
        if (_activeness)
        {
            transform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
        }
    }

    private void OnMouseUp()
    {
        if (_activeness)
        {
            transform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
            _uiManager.OpenPanel(_pauseMenu);
            _dialogueManager.PauseDialogPlaying();
            TryPauseMusic();
            TryPauseSpeech();
            TryPauseEnvironmentSound();
            _pauseCollider.enabled = true;
        }
    }
    public void TryPauseMusic()
    {
        _musicPlayer.TryPauseMusic();
    }

    public void TryPauseSpeech()
    {
        _speechPlayer.TryPause();
    }

    public void TryPauseEnvironmentSound()
    {
        _environmentPlayer.TryPause();
    }
}
