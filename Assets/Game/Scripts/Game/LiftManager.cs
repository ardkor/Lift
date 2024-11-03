using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftManager : MonoBehaviour
{
    [SerializeField] private Animator _anim;

    [SerializeField] private Sprite _liftOpened;
    [SerializeField] private Sprite _liftClosed;
    [SerializeField] private SpriteRenderer _liftRenderer;
    //[SerializeField] private bool _liftStatus;

    public void SwitchLiftStatus(bool liftStatus)
    {
        if (liftStatus)
        {
            _anim.SetTrigger("open_lift");
        }
        else
        {
            _anim.SetTrigger("close_lift");
        }
    }

    public void SetLiftSpriteStatus(bool liftStatus)
    {
        _anim.SetBool("lift_openness", liftStatus);
        /*if (liftStatus)
        {
            _liftRenderer.sprite = _liftOpened;
        }
        else
        {
            Debug.Log("éîó");
            _liftRenderer.sprite = _liftClosed;
        }*/
        
    }

}
