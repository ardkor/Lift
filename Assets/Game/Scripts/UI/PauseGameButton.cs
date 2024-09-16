using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameButton : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private SpeechPlayer _speechPlayer;
    [SerializeField] private MusicPlayer _musicPlayer;
    [SerializeField] private GameObject _pauseMenu;

    private UIManager _uiManager;
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite unpressedSprite;
    private SpriteRenderer spriteRenderer;
    private bool _activeness = true;

    private void Awake()
    {
        _uiManager = FindObjectOfType<UIManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (_activeness)
        {
            spriteRenderer.sprite = pressedSprite;
        }
    }


    private void OnMouseUp()
    {
        if (_activeness)
        {
            spriteRenderer.sprite = unpressedSprite;
            _uiManager.OpenPanel(_pauseMenu);
            _dialogueManager.PauseDialogPlaying();
            TryPauseMusic();
            TryPauseSpeech();
        }
    }
    public void TryPauseMusic()
    {
        _musicPlayer.TryPauseMusic();
    }

    public void TryPauseSpeech()
    {
        _speechPlayer.TryPauseSpeech();
    }
}
