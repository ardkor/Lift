using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISlider : Slider
{
    [SerializeField] protected Sprite _pressedSprite;
    [SerializeField] protected Sprite _unpressedSprite;

    protected Image _image;
    protected RectTransform _rt;
    protected ButtonData _buttonData;
    protected float _angle;
    override protected void  Start()
    {
        //base.Start();
        _rt = gameObject.GetComponent<RectTransform>();
        _image = gameObject.GetComponent<Image>();
        _buttonData = gameObject.GetComponent<ButtonData>();
        _pressedSprite = _buttonData.Data.PressedSliderButton;
        _unpressedSprite = _buttonData.Data.UnpressedSliderButton;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        _image.sprite = _pressedSprite;
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _image.sprite = _unpressedSprite;
        base.OnPointerUp(eventData);
    }
    public void RotationUpdate()
    {
        _angle = -360f * value;
        _rt.rotation = Quaternion.Euler(0, 0, _angle); 
    }
}
