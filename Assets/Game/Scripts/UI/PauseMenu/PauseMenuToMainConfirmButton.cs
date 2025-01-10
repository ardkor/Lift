using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuToMainConfirmButton : SmallUIButton
{
    private DialogueManager _dialogueManager;

    private PauseCollider _pauseCollider;

    private GameObject _pauseMenu;
    private GameObject _mainMenu;
    private GameObject _gameScene;
    private GameObject _mainMenuEnterConfirmationPanel;

    override protected void Start()
    {
        StartButton();
        _pauseCollider = _buttonData.Data.PauseCollider;
        _pauseMenu = _buttonData.Data.PauseMenu;
        _dialogueManager = _buttonData.Data.DialogueManager;
        _mainMenu = _buttonData.Data.MainMenu;
        _gameScene = _buttonData.Data.GameScreen;
        _mainMenuEnterConfirmationPanel = _buttonData.Data.MainMenuEnterConfirmationPanel;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _pauseMenu.SetActive(false);
        _mainMenuEnterConfirmationPanel.SetActive(false);
        _mainMenu.SetActive(true);
        _gameScene.SetActive(false);
        _dialogueManager.ContinueDialogPlaying();
        _pauseCollider.DisableCollider();
    }
}
