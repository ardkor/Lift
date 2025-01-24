using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private GameObject _exitConfirmation;
    [SerializeField] private GameObject _menuEnterConfirmation;
    [SerializeField] private GameObject _newGameConfirmation;

    [SerializeField] private GameObject _gameMenu;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _pauseMenu;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _buttonsPudMenu;

    [SerializeField] private Collider2D _pauseCollider;

    [SerializeField] private UIManager _uiManager;
    [SerializeField] private PauseGameButton _pauseGame;
    [SerializeField] private AudioPlayersManager _audioPlayersManager;

    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private DialogManager _dialogManager;

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_pauseMenu.activeSelf)
            {
                return;
            }
            else if (_gameMenu.activeSelf)
            {
                _dialogManager.NextPhrase();
                return;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (_menuEnterConfirmation.activeSelf)
            {
                _uiManager.ClosePanel(_menuEnterConfirmation);
                _uiManager.ClosePanel(_pauseMenu);
                _uiManager.OpenPanel(_mainMenu);
                _uiManager.ClosePanel(_gameMenu);
            }

            if (_exitConfirmation.activeSelf)
            {
                _uiManager.Exit();
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_newGameConfirmation.activeSelf)
            {
                _uiManager.ClosePanel(_newGameConfirmation);
                return;
            }
            if (_settingsMenu.activeSelf)
            {
                _uiManager.ClosePanel(_settingsMenu);
                return;
            }
            if (_menuEnterConfirmation.activeSelf)
            {
                _uiManager.ClosePanel(_menuEnterConfirmation);
                return;
            }

            if (_exitConfirmation.activeSelf)
            {
                _uiManager.ClosePanel(_exitConfirmation);
                return;
            }

            if (_pauseMenu.activeSelf)
            {
                _dialogueManager.ContinueDialogPlaying();
                _uiManager.ClosePanel(_pauseMenu);
                _audioPlayersManager.TryContinueMusic();
                _audioPlayersManager.TryContinueSpeech();
                _pauseCollider.enabled = false;
                return;
            }
            else if (_gameMenu.activeSelf)
            {
                if (!_buttonsPudMenu.activeSelf)
                {
                    _dialogueManager.PauseDialogPlaying();
                    _uiManager.OpenPanel(_pauseMenu);
                    _pauseGame.TryPauseMusic();
                    _pauseGame.TryPauseSpeech();
                    _pauseCollider.enabled = true;
                    return;
                }
            }
        }
    }
}
