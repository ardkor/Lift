using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UITextButton : UIBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private UIDropdown _uIDropdown;
    public virtual void OnPointerDown(PointerEventData eventData)
    {
       // _uIDropdown.DoOnPointerDown(eventData);
    }
    public virtual void OnPointerUp(PointerEventData eventData)
    {
       // _uIDropdown.DoOnPointerUp(eventData);
    }
}
