using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class UIButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler, Pressable
{
    /*    protected Sprite _pressedSprite;
        protected Sprite _unpressedSprite;

        protected Image _image;
        protected ButtonData _buttonData;
        public void StartButton()
        {
            //base.Start();
            _image = gameObject.GetComponent<Image>();
            _buttonData = gameObject.GetComponent<ButtonData>();
            _pressedSprite = _buttonData.Data.PressedButton;
            _unpressedSprite = _buttonData.Data.UnpressedButton;
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

    protected Image _image;
    protected RectTransform _rectTransform;
    protected ButtonData _buttonData;

    public void StartButton()
    {
        //base.Start();
        _image = gameObject.GetComponent<Image>();
        _buttonData = gameObject.GetComponent<ButtonData>();
        _image = gameObject.GetComponent<Image>();
        _rectTransform = gameObject.GetComponent<RectTransform>();
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        //_rectTransform.sizeDelta = new Vector2(pressedWidth, pressedHeigth);
        _rectTransform.localScale = new Vector2(Pressable.pressedScale, Pressable.pressedScale);
        // base.OnPointerDown(eventData);
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        //_rectTransform.sizeDelta = new Vector2(standartWidth, standartHeigth);
        _rectTransform.localScale = new Vector2(Pressable.standartScale, Pressable.standartScale);
        // base.OnPointerUp(eventData);

    }
}
