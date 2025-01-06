using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class TestUIButton : Button
{
    private const float standartWidth = 160;
    private const float standartHeigth = 160;

    private const float pressedWidth = 140;
    private const float pressedHeigth = 140;

    protected Image _image;
    protected RectTransform _rectTransform;
    protected ButtonData _buttonData;

    protected override void Start()
    {
        //base.Start();
        _image = gameObject.GetComponent<Image>();
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _buttonData = gameObject.GetComponent<ButtonData>();
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
        _rectTransform.sizeDelta = new Vector2(pressedWidth, pressedHeigth);
        // base.OnPointerDown(eventData);
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _rectTransform.sizeDelta = new Vector2(standartWidth, standartHeigth);
        // base.OnPointerUp(eventData);

    }
}
