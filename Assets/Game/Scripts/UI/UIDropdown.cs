using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIDropdown : TMP_Dropdown
{
    [SerializeField] protected Sprite _pressedSprite;
    [SerializeField] protected Sprite _unpressedSprite;

    protected Image _image;
    protected ButtonData _buttonData;
    override protected void Start()
    {
        base.Start();
        _image = gameObject.GetComponent<Image>();
        _buttonData = gameObject.GetComponent<ButtonData>();
        _pressedSprite = _buttonData.Data.PressedListButton;
        _unpressedSprite = _buttonData.Data.UnpressedListButton;
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
}
