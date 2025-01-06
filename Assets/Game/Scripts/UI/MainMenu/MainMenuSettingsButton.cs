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
        _settingsMenu = _buttonData.Data.SettingsMenu;
        _uIManager = _buttonData.Data.UIManager;
    }



    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _uIManager.OpenPanel(_settingsMenu);
    }
}
