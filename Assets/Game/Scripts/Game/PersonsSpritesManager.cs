using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonsSpritesManager : MonoBehaviour
{
    [SerializeField] private Sprite[] _officerSprites;
    [SerializeField] private Sprite[] _detectiveSprites;
    [SerializeField] private Sprite[] _killerSprites;

    [SerializeField] private GameObject _officer;
    [SerializeField] private GameObject _detective;
    [SerializeField] private GameObject _killer;

    [SerializeField] private List<PersonPosition> _personPositions;

    private float _darkenedColorValue = 0.7f;
    private float _originalColorValue = 1;

    private Color _darkenedColor;
    private Color _originalColor;

    [System.Serializable]
    private class PersonPosition
    {
        public string name;
        public float posX;
        public float posY;
    }

    private SpriteRenderer _officerSpriteRenderer;
    private SpriteRenderer _detectiveSpriteRenderer;
    private SpriteRenderer _killerSpriteRenderer;

    private void Awake()
    {
        _officerSpriteRenderer = _officer.GetComponent<SpriteRenderer>();
        _detectiveSpriteRenderer = _detective.GetComponent<SpriteRenderer>();
        _killerSpriteRenderer = _killer.GetComponent<SpriteRenderer>();
        _originalColor = _officerSpriteRenderer.color;

        _darkenedColor = new Color(_darkenedColorValue, _darkenedColorValue, _darkenedColorValue);
        _originalColor = new Color(_originalColorValue, _originalColorValue, _originalColorValue);
    }
    public void HideImages()
    {
        _officerSpriteRenderer.enabled = false;
        _detectiveSpriteRenderer.enabled = false;
        _killerSpriteRenderer.enabled = false;
    }

    private void SetPersonPosition(Transform personTransform, string name)
    {
        foreach (PersonPosition personPosition in _personPositions)
        {
            if (personPosition.name == name)
            {
                personTransform.position = new Vector2(personPosition.posX, personPosition.posY);
                return;
            }
        }
    }

    public void SetOfficerTransform(string name)
    {
        SetPersonPosition(_officer.transform, name);
    }
    public void SetDetectiveTransform(string name)
    {
        SetPersonPosition(_detective.transform, name);
    }
    public void SetKillerTransform(string name)
    {
        SetPersonPosition(_killer.transform, name);
    }

    public void SetActivenessOfficer(bool isActive)
    {
        _officerSpriteRenderer.enabled = isActive;
    }
    public void SetActivenessDetective(bool isActive)
    {
        _detectiveSpriteRenderer.enabled = isActive;
    }
    public void SetActivenessKiller(bool isActive)
    {
        _killerSpriteRenderer.enabled = isActive;
    }

    public void SetFlipOfficer(bool isFlip)
    {
        _officerSpriteRenderer.flipX = isFlip;
    }
    public void SetFlipDetective(bool isFlip)
    {
        _detectiveSpriteRenderer.flipX = isFlip;
    }
    public void SetFlipKiller(bool isFlip)
    {
        _killerSpriteRenderer.flipX = isFlip;
    }

    public void SetOfficerSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Officer_1":
                _officerSpriteRenderer.sprite = _officerSprites[0]; break;
            case "Officer_2":
                _officerSpriteRenderer.sprite = _officerSprites[1]; break;
            case "Officer_3":
                _officerSpriteRenderer.sprite = _officerSprites[2]; break;
            default:
                break;
        }
    }
    public void SetDetectiveSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Detective_1":
                _detectiveSpriteRenderer.sprite = _detectiveSprites[0]; break;
            case "Detective_2":
                _detectiveSpriteRenderer.sprite = _detectiveSprites[1]; break;
            case "Detective_3":
                _detectiveSpriteRenderer.sprite = _detectiveSprites[2]; break;
            default:
                break;
        }
    }
    public void SetKillerSprite(string spriteName)
    {
        switch (spriteName)
        {
            case "Killer_1":
                _killerSpriteRenderer.sprite = _killerSprites[0]; break;
            case "Killer_2":
                _killerSpriteRenderer.sprite = _killerSprites[1]; break;
            case "Killer_3":
                _killerSpriteRenderer.sprite = _killerSprites[2]; break;
            default:
                break;
        }
    }

    private void SetPersonBlackout(SpriteRenderer personSprite, bool isDarkened)
    {
        if (isDarkened)
        {
            //personSprite.color = new Color(darkenedColorValue, darkenedColorValue, darkenedColorValue);
            personSprite.color = _darkenedColor;
        }
        else
        {
            //personSprite.color = new Color(usualColorValue, usualColorValue, usualColorValue);
            personSprite.color = _originalColor;
        }
    }

    public void SetOfficerBlackout(bool isDarkened)
    {
        SetPersonBlackout(_officerSpriteRenderer, isDarkened);
    }
    public void SetDetectiveBlackout(bool isDarkened)
    {
        SetPersonBlackout(_detectiveSpriteRenderer, isDarkened);
    }
    public void SetKillerBlackout(bool isDarkened)
    {
        SetPersonBlackout(_killerSpriteRenderer, isDarkened);
    }

    private void SetPersonSize(SpriteRenderer personSprite, float size)
    {
        personSprite.size.Set(size, size);
    }

    public void SetOfficerSize(float size)
    {
        SetPersonSize(_officerSpriteRenderer, size);
    }
    public void SetDetectiveSize(float size)
    {
        SetPersonSize(_detectiveSpriteRenderer, size);
    }
    public void SetKillerSize(float size)
    {
        SetPersonSize(_killerSpriteRenderer, size);
    }
}
