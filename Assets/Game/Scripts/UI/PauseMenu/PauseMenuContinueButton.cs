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
        _audioPlayersManager = _uiData.Data.AudioPlayersManager;
        _pauseMenu = _uiData.Data.PauseMenu;
        _dialogueManager = _uiData.Data.DialogueManager;
        _pauseCollider = _uiData.Data.PauseCollider;
    }
    public override void DoOnPointerDown()
    {
        base.DoOnPointerDown();
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        DoOnPointerUp();
    }
    public override void DoOnPointerUp()
    {
        base.DoOnPointerUp();
        _pauseMenu.SetActive(false);
        _audioPlayersManager.TryContinueMusic();
        _audioPlayersManager.TryContinueSpeech();
        _audioPlayersManager.TryContinueEnvironmentSound();
        _dialogueManager.ContinueDialogPlaying();
        _pauseCollider.DisableCollider();
    }
}
