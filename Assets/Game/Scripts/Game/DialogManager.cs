/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using TMPro;
//using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    //[SerializeField] private TMP_Text _dialogText;
    [SerializeField] private DialogueManager _dialogueManager;
    private string _futureText;
    private int _currentPhraseIndex;

    public delegate void DialogEndedHandler();
    public event DialogEndedHandler DialogEnded;
    // public event UnityAction DialogEnded;

    /*    private void LoadPhrase() 
        {
            PlayerPrefs.GetInt("CurrentPhraseIndex", 0);
            _dialogText.text = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].Text;
        }
        private void SavePhrase()
        {
            PlayerPrefs.SetInt("CurrentPhraseIndex", _currentPhraseIndex);
        }*/
    public void SetIndexToFirstPhase()
    {
        _currentPhraseIndex = 0;
    }
    public void FirstPhrase()
    {
        _futureText = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].Text;
        _currentPhraseIndex = 0;
    }
    public void NextPhrase()
    {
        if (_currentPhraseIndex+1 == _dialogScenesManager._currentScene.Dialog.Phrases.Length)
        {
            DialogEnded();
            return;
        }
        _currentPhraseIndex++;
        _futureText = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].Text;
        _dialogueManager.PlayMyDialogue(_futureText);
    }

}
