using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class TestUIButton : Button
{
    private const float standartWidth = 80;
    private const float standartHeigth = 80;

    private const float pressedWidth = 70;
    private const float pressedHeigth = 70;

    protected Image _image;
    protected RectTransform _rectTransform;
    protected UIData _uiData;

    protected override void Start()
    {
        //base.Start();
        _image = gameObject.GetComponent<Image>();
        _rectTransform = gameObject.GetComponent<RectTransform>();
        _uiData = gameObject.GetComponent<UIData>();
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
