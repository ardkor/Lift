using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuExitButton : UIButton
{
    private GameObject _exitConfirmationPanel;

    override protected void Start()
    {
        StartButton();
        _exitConfirmationPanel = _uiData.Data.ExitConfirmationPanel;
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
        _exitConfirmationPanel.SetActive(true);
    }
}
