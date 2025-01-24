using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuContinueButton : UIButton
{
    private PauseCollider _pauseCollider;
    private GameObject _pauseMenu;
    private AudioPlayersManager _audioPlayersManager;
    private DialogueManager _dialogueManager;

    override protected void Start()
    {
        StartButton();
        _audioPlayersManager = _buttonData.Data.AudioPlayersManager;
        _pauseMenu = _buttonData.Data.PauseMenu;
        _dialogueManager = _buttonData.Data.DialogueManager;
        _pauseCollider = _buttonData.Data.PauseCollider;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _pauseMenu.SetActive(false);
        _audioPlayersManager.TryContinueMusic();
        _audioPlayersManager.TryContinueSpeech();
        _audioPlayersManager.TryContinueEnvironmentSound();
        _dialogueManager.ContinueDialogPlaying();
        _pauseCollider.DisableCollider();
    }
}
