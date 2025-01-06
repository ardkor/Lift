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
        _uIManager = _buttonData.Data.UIManager;
        _settingsMenu = _buttonData.Data.SettingsMenu;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _uIManager.ClosePanel(_settingsMenu);
    }
}
