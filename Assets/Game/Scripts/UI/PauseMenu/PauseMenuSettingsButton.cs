using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMenuSettingsButton : UIButton
{
    private GameObject _settingsMenu;

    override protected void Start()
    {
        StartButton();
        _settingsMenu = _buttonData.Data.SettingsMenu;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _settingsMenu.SetActive(true);
    }
}
