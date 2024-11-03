using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class ExitButton : UIButton
{
    [SerializeField] private UIManager _uIManager;

    private void Start()
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
