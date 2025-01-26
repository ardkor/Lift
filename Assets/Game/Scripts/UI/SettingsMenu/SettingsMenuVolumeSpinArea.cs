using UnityEngine;
using UnityEngine.UI;
using TMPro;
using NaughtyAttributes;
using System.Collections.Generic;
using ChrisTutorials.Persistent;
using UnityEngine.EventSystems;

public class SettingsMenuVolumeSpinArea : UISpinButton
{
    [SerializeField] private TMP_Text _volumeText;

    [SerializeField] private bool _isEffect;
    [EnableIf("_isEffect")]
    [SerializeField] private AudioClip _effectClip;
    [Dropdown("_mixersValues")]
    [SerializeField] private string _audioChannelName;

    private List<string> _mixersValues { get { return new List<string>() { "MasterVolume", "MusicVolume", "SoundVolume" }; } }

    //private bool _buttonHold;
    private AudioSource _audioSource;
    private float _value;
    private void Start()
    {
        //Debug.Log(PlayerPrefs.GetInt(_audioChannelName, 50) );
        _value = PlayerPrefs.GetInt(_audioChannelName, 50);
        _volumeText.text = "" + PlayerPrefs.GetInt(_audioChannelName, 50);
        RotationUpdate(_value);
    }
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        _value = _angle / -3.6f;
        SetVolume();
        PlayerPrefs.SetInt(_audioChannelName, System.Convert.ToInt32(_value));

        if (_isEffect)
        {
            _audioSource = AudioManager.Instance.PlayLoop(_effectClip, transform, 1f, 1f, false);
        }
        _volumeText.text = "" + System.Convert.ToInt32(_value);
    }
    public override void OnDrag(PointerEventData eventData)
    {
        base.OnDrag(eventData);
        _value = _angle / -3.6f;
        SetVolume();
        PlayerPrefs.SetInt(_audioChannelName, System.Convert.ToInt32(_value));
        _volumeText.text = "" + System.Convert.ToInt32(_value);
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        if (_isEffect)
        {
            Destroy(_audioSource.gameObject);
        }
    }
    /*public void SliderTriggering(bool button) 
    {
        _buttonHold = button;
        SetSliderVolume();
        PlayerPrefs.SetInt(_audioChannelName, System.Convert.ToInt32(_slider.value * 100));

        if (_effectSound)
        {
            if (_buttonHold)
                _audioSource = AudioManager.Instance.PlayLoop(_audioClip, transform, 1f, 1f, false);
            else
                Destroy(_audioSource.gameObject);
        }
        _volumeText.text = "" + System.Convert.ToInt32(_slider.value * 100);

    }

    public void SliderMoving() 
    {
        SetSliderVolume();
        PlayerPrefs.SetInt(_audioChannelName, System.Convert.ToInt32(_slider.value * 100));
        _volumeText.text = "" + System.Convert.ToInt32(_slider.value * 100);  
    }*/

    private void SetVolume()
    {
        switch (_audioChannelName)
        {
            case "MasterVolume":
                AudioManager.Instance.SetVolume(AudioManager.AudioChannel.Master, System.Convert.ToInt32(_value));
                break;

            case "MusicVolume":
                AudioManager.Instance.SetVolume(AudioManager.AudioChannel.Music, System.Convert.ToInt32(_value));
                break;

            case "SoundVolume":
                AudioManager.Instance.SetVolume(AudioManager.AudioChannel.Sound, System.Convert.ToInt32(_value));
                break;
        }
    }
}


