using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;
using ChrisTutorials.Persistent;

[RequireComponent(typeof(UIData))]
public class UIButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler, Pressable
{
    /*    protected Sprite _pressedSprite;
        protected Sprite _unpressedSprite;

        protected Image _image;
        protected ButtonData _uiData;
        public void StartButton()
        {
            //base.Start();
            _image = gameObject.GetComponent<Image>();
            _uiData = gameObject.GetComponent<ButtonData>();
            _pressedSprite = _uiData.Data.PressedButton;
            _unpressedSprite = _uiData.Data.UnpressedButton;
        }

        public virtual void OnPointerDown(PointerEventData eventData)
        {

            _image.sprite = _pressedSprite;
            // base.OnPointerDown(eventData);
        }

        public virtual void OnPointerUp(PointerEventData eventData)
        {
            _image.sprite = _unpressedSprite;
            // base.OnPointerUp(eventData);

        }*/

/*    protected const float standartWidth = 80;
    protected const float standartHeigth = 80;

    protected const float pressedWidth = 70;
    protected const float pressedHeigth = 70;*/

/*    protected const float standartScale = 1;
    protected const float pressedScale = 0.8f;*/

    //protected Image _image;
    protected RectTransform _rectTransform;
    protected UIData _uiData;
    protected AudioClip _buttonPushedClip;
    protected GameObject _buttonPushedSource;
    public void StartButton()
    {
        //base.Start();
        //_image = gameObject.GetComponent<Image>();
        _uiData = gameObject.GetComponent<UIData>();
        _buttonPushedClip = _uiData.Data.ButtonPushedClip;
        _buttonPushedSource = _uiData.Data.ButtonPushedSource;
        _rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        DoOnPointerDown();
        //_rectTransform.sizeDelta = new Vector2(pressedWidth, pressedHeigth);
        // base.OnPointerDown(eventData);
    }
    public virtual void DoOnPointerDown()
    {
        _rectTransform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
        DoOnPointerUp();
        //_rectTransform.sizeDelta = new Vector2(standartWidth, standartHeigth);
        // base.OnPointerUp(eventData);
    }
    public virtual void DoOnPointerUp()
    {
        AudioManager.Instance.Play(_buttonPushedClip, _buttonPushedSource.transform, 1f, 1f);
        _rectTransform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
    }
}
