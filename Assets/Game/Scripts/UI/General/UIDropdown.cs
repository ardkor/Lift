using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
using ChrisTutorials.Persistent;

[RequireComponent(typeof(UIData))]
public class UIDropdown : TMP_Dropdown, Pressable
{

    protected UIData _uiData;
    protected AudioClip _buttonPushedClip;
    protected GameObject _buttonPushedSource;
    protected RectTransform _rectTransform;

    override protected void Start()
    {
        base.Start();
        _uiData = gameObject.GetComponent<UIData>();
        _buttonPushedClip = _uiData.Data.ButtonPushedClip;
        _buttonPushedSource = _uiData.Data.ButtonPushedSource;
        _rectTransform = gameObject.GetComponent<RectTransform>();
    }
/*    public override void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
        base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _rectTransform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
        base.OnPointerUp(eventData);
    }*/

    public override void OnPointerDown(PointerEventData eventData)
    {
       // base.OnPointerDown(eventData);
        DoOnPointerDown();
    }
    public virtual void DoOnPointerDown()
    {
        _rectTransform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        //base.OnPointerUp(eventData);
        DoOnPointerUp();
    }
    public virtual void DoOnPointerUp()
    {
        Show();
        AudioManager.Instance.Play(_buttonPushedClip, _buttonPushedSource.transform, 1f, 1f);
        _rectTransform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
    }
}
