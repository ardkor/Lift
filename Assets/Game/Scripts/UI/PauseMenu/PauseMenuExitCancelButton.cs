using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenuExitCancelButton : UIButton
{
    private GameObject _exitConfirmationMenu;

    override protected void Start()
    {
        StartButton();
        _exitConfirmationMenu = _uiData.Data.ExitConfirmationPanel;
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
        _exitConfirmationMenu.SetActive(false);
    }
}
