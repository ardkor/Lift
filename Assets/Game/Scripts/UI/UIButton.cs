using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class UIButton : Button
{
    [SerializeField] protected Sprite _pressedSprite;
    [SerializeField] protected Sprite _unpressedSprite;

    protected Image _image;
    protected ButtonData _buttonData;

    public void StartButton()
    {
        _image = gameObject.GetComponent<Image>();
        _buttonData = gameObject.GetComponent<ButtonData>();
        _pressedSprite = _buttonData.Data.PressedButton;
        _unpressedSprite = _buttonData.Data.UnpressedButton;
    }

    public override void OnPointerDown(PointerEventData eventData)
    {

        _image.sprite = _pressedSprite;
        // base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _unpressedSprite;
        // base.OnPointerUp(eventData);

    }
}
