using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SettingsMenuBackButton : UIButton
{
    private UIManager _uIManager;
    private GameObject _settingsMenu;

    override protected void Start()
    {
        StartButton();
        _uIManager = _uiData.Data.UIManager;
        _settingsMenu = _uiData.Data.SettingsMenu;
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
        _uIManager.ClosePanel(_settingsMenu);
    }
}
