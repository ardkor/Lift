using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuToMainCancelButton : UIButton
{
    private GameObject _mainMenuEnterConfirmationPanel;

    override protected void Start()
    {
        StartButton();
        _mainMenuEnterConfirmationPanel = _uiData.Data.MainMenuEnterConfirmationPanel;
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
        _mainMenuEnterConfirmationPanel.SetActive(false);
    }
}
