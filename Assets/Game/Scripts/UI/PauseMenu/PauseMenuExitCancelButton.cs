using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenuExitCancelButton : UIButton
{
    private GameObject _exitConfirmationMenu;

    override protected void Start()
    {
        StartButton();
        _exitConfirmationMenu = _buttonData.Data.ExitConfirmationPanel;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _exitConfirmationMenu.SetActive(false);
    }
}
