using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class NewGameButton : UIButton
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _confirmationPanel;
    [SerializeField] private DialogScenesManager _dialogScenesManager;

    private void Start()
    {
        StartButton();
        _mainMenu = _buttonData.Data.MainMenu;
        _gameScreen = _buttonData.Data.GameScreen;
        _confirmationPanel = _buttonData.Data.ConfirmationPanel;
        _dialogScenesManager = _buttonData.Data.DialogScenesManager;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        TryStartNewGame();
    }
    public void TryStartNewGame()
    {
        if (PlayerPrefs.HasKey("CurrentSceneIndex"))
        {
            _confirmationPanel.SetActive(true);
        }
        else
        {
            StartNewGame();
        }
    }

    public void StartNewGame()
    {
        _gameScreen.SetActive(true);
        _dialogScenesManager.LoadFirstScene();
        _mainMenu.SetActive(false);
    }

}
