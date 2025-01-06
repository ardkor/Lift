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
        _mainMenu = _buttonData.Data.MainMenu;
        _confirmationPanel = _buttonData.Data.NewGameConfirmationPanel;
        _newGameButton = _buttonData.Data.NewGameButton;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _confirmationPanel.SetActive(false);
        _mainMenu.SetActive(false);
        _newGameButton.StartNewGame();
    }
}
