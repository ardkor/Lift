using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuLoadGameButton : UIButton
{
    private DialogScenesManager _dialogScenesManager;
    private DialogueManager _dialogueManager;
    private PauseCollider _pauseCollider;
    private GameObject _pauseMenu;

    public void LoadGame()
    {
        _dialogScenesManager.LoadCurrentScene();
    }

    override protected void Start()
    {
        StartButton();
        _dialogScenesManager = _buttonData.Data.DialogScenesManager;
        _pauseCollider = _buttonData.Data.PauseCollider;
        _pauseMenu = _buttonData.Data.PauseMenu;
        _dialogueManager = _buttonData.Data.DialogueManager;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        LoadGame();
        _pauseMenu.SetActive(false);
        _dialogueManager.ContinueDialogPlaying();
        _pauseCollider.DisableCollider();
    }
}
