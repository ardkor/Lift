using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FloorUIButton : UIButton
{
    public int Num => _num;

    [SerializeField] private int _num;

    private DialogScenesManager _dialogScenesManager;
    private bool _activeness;

    protected override void Start()
    {
        StartButton();
        _dialogScenesManager = FindObjectOfType<DialogScenesManager>();
    }
    public void SetActiveness(bool activeness)
    {
        _activeness = activeness;
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        DoOnPointerDown();
    }
    public override void DoOnPointerDown()
    {
        if (_activeness)
        {
            base.DoOnPointerDown();
            _rectTransform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
        }
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        DoOnPointerUp();
    }
    public override void DoOnPointerUp()
    {
        if (_activeness)
        {
            base.DoOnPointerUp();
            _rectTransform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
            _dialogScenesManager.NextDialog(_num);
        }
    }
}
