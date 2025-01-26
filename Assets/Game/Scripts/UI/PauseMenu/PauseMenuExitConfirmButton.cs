using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class PauseMenuExitConfirmButton : UIButton
{
    private UIManager _uIManager;

    override protected void Start()
    {
        StartButton();
        _uIManager = _uiData.Data.UIManager;
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
        _uIManager.Exit();
    }
}
