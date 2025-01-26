using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using ChrisTutorials.Persistent;

[RequireComponent(typeof(UIData))]
public class UISpinButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler, Pressable
{
    [SerializeField] private Image _uiImage;

    private RectTransform _activeImageRect;
    protected AudioClip _buttonPushedClip;
    protected GameObject _buttonPushedSource;
    protected UIData _uiData;
    private Vector2 _center;
    private Vector2 _pointerPosition;

    protected float _angle;

    protected void Awake()
    {
        _activeImageRect = _uiImage.rectTransform;
        _center = _activeImageRect.position;
        _uiData = gameObject.GetComponent<UIData>();
        _buttonPushedClip = _uiData.Data.ButtonPushedClip;
        _buttonPushedSource = _uiData.Data.ButtonPushedSource;
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        _activeImageRect.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
        _pointerPosition = eventData.position;
        RotationUpdate();
    }
    public virtual void OnDrag(PointerEventData eventData)
    {
        _pointerPosition = eventData.position;
        RotationUpdate();
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        AudioManager.Instance.Play(_buttonPushedClip, _buttonPushedSource.transform, 1f, 1f);
        _activeImageRect.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
    }
    private void CalculateAngle()
    {
        _center = _activeImageRect.position;
        Vector2 direction = _pointerPosition - _center;
        float initAngle = (Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg);
        initAngle = -initAngle;
        if (initAngle < 0)
        {
            _angle = initAngle;
        }
        else
        {
            _angle = initAngle - 360;
        }
    }
    private void RotationUpdate()
    {
        CalculateAngle();
        _activeImageRect.rotation = Quaternion.Euler(0, 0, _angle);
    }
    protected void RotationUpdate(float value)
    {
        _angle = value * -3.6f;
        _activeImageRect.rotation = Quaternion.Euler(0, 0, _angle);
    }
}
