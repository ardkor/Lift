using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class UIButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler
{
    protected Sprite _pressedSprite;
    protected Sprite _unpressedSprite;

    protected Image _image;
    protected ButtonData _buttonData;
    public void StartButton()
    {
        //base.Start();
        _image = gameObject.GetComponent<Image>();
        _buttonData = gameObject.GetComponent<ButtonData>();
        _pressedSprite = _buttonData.Data.PressedButton;
        _unpressedSprite = _buttonData.Data.UnpressedButton;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {

        _image.sprite = _pressedSprite;
        // base.OnPointerDown(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _unpressedSprite;
        // base.OnPointerUp(eventData);

    }
}
