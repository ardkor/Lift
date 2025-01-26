using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ChrisTutorials.Persistent;

[RequireComponent(typeof(UIData))]
public class UISlider : Slider, Pressable
{
    /*    [SerializeField] protected Sprite _pressedSprite;
        [SerializeField] protected Sprite _unpressedSprite;*/
    protected UIData _uiData;
    protected AudioClip _buttonPushedClip;
    protected GameObject _buttonPushedSource;
    protected RectTransform _rectTransform;

    protected float _angle;
    /*    override protected void  Awake()
        {
            //base.Start();
            _uiData = gameObject.GetComponent<ButtonData>();
            //_rectTransform = _uiData.Data.MasterVolumeRect;
        }*/


    override protected void Start()
    {
        base.Start();
        _uiData = gameObject.GetComponent<UIData>();
        _buttonPushedClip = _uiData.Data.ButtonPushedClip;
        _buttonPushedSource = _uiData.Data.ButtonPushedSource;
        _rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public void RotationUpdate()
    {
        _angle = -360f * value;
        _rectTransform.rotation = Quaternion.Euler(0, 0, _angle);
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        DoOnPointerDown();
    }
    public virtual void DoOnPointerDown()
    {
        _rectTransform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        DoOnPointerUp();
    }
    public virtual void DoOnPointerUp()
    {
        AudioManager.Instance.Play(_buttonPushedClip, _buttonPushedSource.transform, 1f, 1f);
        _rectTransform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
    }
}