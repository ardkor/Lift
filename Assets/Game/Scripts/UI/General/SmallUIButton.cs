using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class SmallUIButton : UIButton
{
    private new const float standartWidth = 70;
    private new const float standartHeigth = 70;

    private new const float pressedWidth = 60;
    private new const float pressedHeigth = 60;

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
