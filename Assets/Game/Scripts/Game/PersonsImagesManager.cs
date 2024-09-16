using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonsImagesManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _officerSprites;
    [SerializeField] private Sprite[] _detectiveSprites;
    [SerializeField] private Sprite[] _killerSprites;

    [SerializeField] private RectTransform _officerTransform;
    [SerializeField] private RectTransform _detectiveTransform;
    [SerializeField] private RectTransform _killerTransform;

    [SerializeField] private Image _officerImage;
    [SerializeField] private Image _detectiveImage;
    [SerializeField] private Image _killerImage;

    public void HideImages()
    {
        _officerImage.enabled = false;
        _detectiveImage.enabled = false;
        _killerImage.enabled = false;
    }
    public void SetOfficerTransform(float posX, float posY)
    {
        _officerTransform.anchoredPosition = new Vector2(posX, posY); 
    }
    public void SetDetectiveTransform(float posX, float posY)
    {
        _detectiveTransform.anchoredPosition = new Vector2(posX, posY);
    }
    public void SetKillerTransform(float posX, float posY)
    {
        _killerTransform.anchoredPosition = new Vector2(posX, posY);
    }

    public void SetActivenessOfficer(bool isActive)
    {
        _officerImage.enabled = isActive;
    }
    public void SetActivenessDetective(bool isActive)
    {
        _detectiveImage.enabled = isActive;
    }
    public void SetActivenessKiller(bool isActive)
    {
        _killerImage.enabled = isActive;
    }
    /*    public void SetPersonSprite(string spriteName)
        {
            switch (spriteName)
            {
                case "Officer_1":
                    _officerImage.sprite = _officerSprites[0]; break;
                case "Officer_2":
                    _officerImage.sprite = _officerSprites[1]; break;
                case "Officer_3":
                    _officerImage.sprite = _officerSprites[2]; break;
                case "Detective_1":
                    _detectiveImage.sprite = _detectiveSprites[0]; break;
                case "Detective_2":
                    _detectiveImage.sprite = _detectiveSprites[1]; break;
                case "Detective_3":
                    _detectiveImage.sprite = _detectiveSprites[2]; break;
                case "Killer_1":
                    _killerImage.sprite = _killerSprites[0]; break;
                case "Killer_2":
                    _killerImage.sprite = _killerSprites[1]; break;
                case "Killer_3":
                    _killerImage.sprite = _killerSprites[2]; break;
                default:
                    break;
            }
        }*/
    public void SetOfficerSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Officer_1":
                _officerImage.sprite = _officerSprites[0]; break;
            case "Officer_2":
                _officerImage.sprite = _officerSprites[1]; break;
            case "Officer_3":
                _officerImage.sprite = _officerSprites[2]; break;
            default:
                break;
        }
    }
    public void SetDetectiveSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Detective_1":
                _detectiveImage.sprite = _detectiveSprites[0]; break;
            case "Detective_2":
                _detectiveImage.sprite = _detectiveSprites[1]; break;
            case "Detective_3":
                _detectiveImage.sprite = _detectiveSprites[2]; break;
            default:
                break;
        }
    }
    public void SetKillerSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Killer_1":
                _killerImage.sprite = _killerSprites[0]; break;
            case "Killer_2":
                _killerImage.sprite = _killerSprites[1]; break;
            case "Killer_3":
                _killerImage.sprite = _killerSprites[2]; break;
            default:
                break;
        }
    }
}
