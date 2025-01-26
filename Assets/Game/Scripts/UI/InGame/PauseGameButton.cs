using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

[RequireComponent(typeof(UIData))]
public class PauseGameButton : MonoBehaviour, Pressable
{
    private DialogueManager _dialogueManager;
    private GameObject _pauseMenu;
    private PauseCollider _pauseCollider;
    private AudioPlayersManager _audioPlayersManager;
    private UIData _uiData;
    private UIManager _uiManager;
    protected AudioClip _buttonPushedClip;
    protected GameObject _buttonPushedSource;

    private bool _activeness = true;

    private void Start()
    {
        _uiData = gameObject.GetComponent<UIData>();
        _buttonPushedClip = _uiData.Data.ButtonPushedClip;
        _buttonPushedSource = _uiData.Data.ButtonPushedSource;
        _dialogueManager = _uiData.Data.DialogueManager;
        _pauseMenu = _uiData.Data.PauseMenu;
        _pauseCollider = _uiData.Data.PauseCollider;
         _audioPlayersManager = _uiData.Data.AudioPlayersManager;
        _uiManager = _uiData.Data.UIManager;
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
            AudioManager.Instance.Play(_buttonPushedClip, _buttonPushedSource.transform, 1f, 1f);
            transform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
            _uiManager.OpenPanel(_pauseMenu);
            _dialogueManager.PauseDialogPlaying();
            _audioPlayersManager.TryPauseMusic();
            _audioPlayersManager.TryPauseSpeech();
            _audioPlayersManager.TryPauseEnvironmentSound();
            _pauseCollider.EnableCollider();
        }
    }
    
}
