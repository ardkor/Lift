using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightBulb : MonoBehaviour
{
    [SerializeField] private int _num;
    [SerializeField] private Data _data;
    public int Num => _num;

    private Sprite activeSprite;
    private Sprite inactiveSprite;
    private bool _activeness;
    private Image _image;

    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
        inactiveSprite =_data.LightBulbOff;
        activeSprite = _data.LightBulbOn;
    }
    public void SetActiveness(bool activeness)
    {
        _activeness = activeness;
        if (_activeness)
        {
            _image.sprite = activeSprite;
        }
        else
        {
            _image.sprite = inactiveSprite;
        }
    }
}
