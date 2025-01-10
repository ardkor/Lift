using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIDropdown : TMP_Dropdown, Pressable
{

    protected RectTransform _rectTransform;
    override protected void Start()
    {
        base.Start();
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
}
