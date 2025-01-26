using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuNewGameCancelButton : UIButton
{
    private GameObject _confirmationPanel;

    override protected void Start()
    {
        StartButton();
        _confirmationPanel = _uiData.Data.NewGameConfirmationPanel;
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
    }
}
