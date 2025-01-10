using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISlider : Slider, Pressable
{
    [SerializeField] protected Sprite _pressedSprite;
    [SerializeField] protected Sprite _unpressedSprite;

    protected RectTransform _rectTransform;
    protected ButtonData _buttonData;
    protected float _angle;
    override protected void  Awake()
    {
        //base.Start();
        _rectTransform = gameObject.GetComponent<RectTransform>();
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _rectTransform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
        base.OnPointerUp(eventData);
    }
    public void RotationUpdate()
    {
        _angle = -360f * value;
        _rectTransform.rotation = Quaternion.Euler(0, 0, _angle); 
    }
}
