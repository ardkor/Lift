using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuSettingsButton : UIButton
{
    private GameObject _settingsMenu;
    private UIManager _uIManager;

    override protected void Start()
    {
        StartButton();
        _settingsMenu = _uiData.Data.SettingsMenu;
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
        _uIManager.OpenPanel(_settingsMenu);
    }
}
