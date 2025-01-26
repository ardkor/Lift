using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuLoadGameButton : UIButton
{
    private DialogScenesManager _dialogScenesManager;
    private DialogueManager _dialogueManager;
    private PauseCollider _pauseCollider;
    private GameObject _pauseMenu;
    private AudioPlayersManager _audioPlayersManager;
    public void LoadGame()
    {
        _dialogScenesManager.LoadCurrentScene();
    }

    override protected void Start()
    {
        StartButton();
        _audioPlayersManager = _uiData.Data.AudioPlayersManager;
        _dialogScenesManager = _uiData.Data.DialogScenesManager;
        _pauseCollider = _uiData.Data.PauseCollider;
        _pauseMenu = _uiData.Data.PauseMenu;
        _dialogueManager = _uiData.Data.DialogueManager;
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
        LoadGame();
        _pauseMenu.SetActive(false);
        _audioPlayersManager.TryContinueMusic();
        _audioPlayersManager.TryContinueSpeech();
        _audioPlayersManager.TryContinueEnvironmentSound();
        _dialogueManager.ContinueDialogPlaying();
        _pauseCollider.DisableCollider();
    }
}
