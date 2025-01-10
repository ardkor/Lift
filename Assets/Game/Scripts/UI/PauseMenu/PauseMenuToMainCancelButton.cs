using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuToMainCancelButton : UIButton
{
    private GameObject _mainMenuEnterConfirmationPanel;

    override protected void Start()
    {
        StartButton();
        _mainMenuEnterConfirmationPanel = _buttonData.Data.MainMenuEnterConfirmationPanel;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _mainMenuEnterConfirmationPanel.SetActive(false);
    }
}
