using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuNewGameConfirmButton : UIButton
{
    private MainMenuNewGameButton _newGameButton;

    private GameObject _mainMenu;
    private GameObject _confirmationPanel;

    override protected void Start()
    {
        StartButton();
        _mainMenu = _uiData.Data.MainMenu;
        _confirmationPanel = _uiData.Data.NewGameConfirmationPanel;
        _newGameButton = _uiData.Data.NewGameButton;
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
        _confirmationPanel.SetActive(false);
        _mainMenu.SetActive(false);
        _newGameButton.StartNewGame();
    }
}
