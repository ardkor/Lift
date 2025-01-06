using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameButton : MonoBehaviour
{
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private SpeechPlayer _speechPlayer;
    [SerializeField] private EnvironmentPlayer _environmentPlayer;
    [SerializeField] private MusicPlayer _musicPlayer;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private Collider2D _pauseCollider;

    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite unpressedSprite;
    private UIManager _uiManager;
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
