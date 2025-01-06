using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuContinueButton : UIButton
{
    private SpeechPlayer _speechPlayer;
    private EnvironmentPlayer _environmentPlayer;
    private MusicPlayer _musicPlayer;
    private DialogueManager _dialogueManager;
    private PauseCollider _pauseCollider;
    private GameObject _pauseMenu;
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

    override protected void Start()
    {
        StartButton();
        _speechPlayer = _buttonData.Data.SpeechPlayer;
        _environmentPlayer = _buttonData.Data.EnvironmentPlayer;
        _musicPlayer = _buttonData.Data.MusicPlayer;
        _pauseMenu = _buttonData.Data.PauseMenu;
        _dialogueManager = _buttonData.Data.DialogueManager;
        _pauseCollider = _buttonData.Data.PauseCollider;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _pauseMenu.SetActive(false);
        TryContinueMusic();
        TryContinueSpeech();
        TryContinueEnvironmentSound();
        _dialogueManager.ContinueDialogPlaying();
        _pauseCollider.DisableCollider();
    }
}
