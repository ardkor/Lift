using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TestClear : MonoBehaviour
{
    [SerializeField] TMP_Text _text;
    [SerializeField] DialogueManager _dialogueManager;
    private string text = "fffffffffffffffffffffffffffffffffffffffffffffffffff";

    private void Start()
    {
       // _dialogueManager.PlayTestDialogue(text);
    }
    public void Cler()
    {
        _text.text = "";
        _text.gameObject.SetActive(false);
        _text.gameObject.SetActive(true);
       // _dialogueManager.ClearText();
    }
}
