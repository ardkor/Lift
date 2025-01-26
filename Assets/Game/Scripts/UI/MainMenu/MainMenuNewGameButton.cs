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
        _mainMenu = _uiData.Data.MainMenu;
        _gameScreen = _uiData.Data.GameScreen;
        _confirmationPanel = _uiData.Data.NewGameConfirmationPanel;
        _dialogScenesManager = _uiData.Data.DialogScenesManager;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        DoOnPointerDown();
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
