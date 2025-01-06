using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuExitButton : UIButton
{
    private GameObject _exitConfirmationPanel;

    override protected void Start()
    {
        StartButton();
        _exitConfirmationPanel = _buttonData.Data.ExitConfirmationPanel;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _exitConfirmationPanel.SetActive(true);
    }
}
