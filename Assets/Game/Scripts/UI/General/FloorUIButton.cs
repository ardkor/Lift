using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FloorUIButton : UIButton
{
    [SerializeField] private int _num;
    [SerializeField] private Data _data;
    public int Num => _num;
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
        if (_activeness)
        {
            _rectTransform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
        }
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        if (_activeness)
        {
            _rectTransform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
            _dialogScenesManager.NextDialog(_num);
        }
    }
}
