using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogButton : MonoBehaviour
{
    [SerializeField] private DialogManager _dialogManager;

    private void OnMouseUp()
    {
        _dialogManager.NextPhrase();
    }
}
