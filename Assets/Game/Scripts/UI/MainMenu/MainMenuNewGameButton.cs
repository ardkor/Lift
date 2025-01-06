using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuNewGameButton : UIButton
{
    private GameObject _mainMenu;
    private GameObject _gameScreen;
    private GameObject _confirmationPanel;
    private DialogScenesManager _dialogScenesManager;

    override protected void Start()
    {
        StartButton();
        _mainMenu = _buttonData.Data.MainMenu;
        _gameScreen = _buttonData.Data.GameScreen;
        _confirmationPanel = _buttonData.Data.NewGameConfirmationPanel;
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
