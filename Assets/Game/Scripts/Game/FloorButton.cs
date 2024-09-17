using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorButton : MonoBehaviour
{
    private DialogScenesManager dialogScenesManager;
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] private Sprite unpressedSprite;
    [SerializeField] private Sprite unactiveSprite;
    private SpriteRenderer spriteRenderer;
    [SerializeField] private int buttonNum;
    private bool _activeness;

    private void Awake()
    {
        dialogScenesManager = FindObjectOfType<DialogScenesManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void SetActiveness(bool activeness) 
    {
        _activeness = activeness;
        if (_activeness)
        {
            spriteRenderer.sprite = unpressedSprite;
        }
        else
        {
            spriteRenderer.sprite = unactiveSprite;
        }
    }
    private void OnMouseDown()
    {
        if (_activeness) 
        {
            spriteRenderer.sprite = pressedSprite;
        }
    }

    private void OnMouseUp()
    {
        if (_activeness)
        {
            spriteRenderer.sprite = unpressedSprite;
            dialogScenesManager.NextDialog(buttonNum);
        }
    }
}
