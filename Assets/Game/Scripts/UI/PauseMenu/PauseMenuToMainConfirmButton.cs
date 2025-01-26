using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuToMainConfirmButton : UIButton
{
    private DialogueManager _dialogueManager;

    private PauseCollider _pauseCollider;

    private AudioPlayersManager _audioPlayersManager;

    private GameObject _pauseMenu;
    private GameObject _mainMenu;
    private GameObject _gameScene;
    private GameObject _mainMenuEnterConfirmationPanel;

    override protected void Start()
    {
        StartButton();
        _audioPlayersManager = _uiData.Data.AudioPlayersManager;
        _pauseCollider = _uiData.Data.PauseCollider;
        _pauseMenu = _uiData.Data.PauseMenu;
        _dialogueManager = _uiData.Data.DialogueManager;
        _mainMenu = _uiData.Data.MainMenu;
        _gameScene = _uiData.Data.GameScreen;
        _mainMenuEnterConfirmationPanel = _uiData.Data.MainMenuEnterConfirmationPanel;
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
        _mainMenuEnterConfirmationPanel.SetActive(false);
        _mainMenu.SetActive(true);
        _gameScene.SetActive(false);
        _audioPlayersManager.TryContinueMusic();
        _audioPlayersManager.TryContinueSpeech();
        _audioPlayersManager.TryContinueEnvironmentSound();
        _dialogueManager.ContinueDialogPlaying();
        _pauseCollider.DisableCollider();
    }
}