using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MainMenuExitButton : UIButton
{
    private UIManager _uIManager;

    override protected void Start()
    {
        StartButton();
        _uIManager = _buttonData.Data.UIManager;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        _uIManager.Exit();
    }
}
