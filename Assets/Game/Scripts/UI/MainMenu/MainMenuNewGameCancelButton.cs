using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuNewGameCancelButton : SmallUIButton
{
    private GameObject _confirmationPanel;

    override protected void Start()
    {
        StartButton();
        _confirmationPanel = _buttonData.Data.NewGameConfirmationPanel;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _confirmationPanel.SetActive(false);
    }
}
