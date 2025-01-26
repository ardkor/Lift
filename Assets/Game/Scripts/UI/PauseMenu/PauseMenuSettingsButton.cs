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
        _settingsMenu.SetActive(true);
    }
}
