/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using TMPro;
//using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    //[SerializeField] private TMP_Text _dialogText;
    [SerializeField] private EffectsPlayer _effectsPlayer;
    [SerializeField] private DialogueManager _dialogueManager;
    private string _futureText;
    private int _currentPhraseIndex;
    private bool _skippingButtonStage;
    private int _skippingButtonNum;

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
    private void Start()
    {
        int skippingButtonStage = PlayerPrefs.GetInt("SkippingButtonStage", 0);
        int skippingButtonNum = PlayerPrefs.GetInt("SkippingButtonNum", 0);
        switch (skippingButtonStage)
        {
            case 0:
                _skippingButtonStage = false; break;
            case 1:
                _skippingButtonStage = true; break;
            default:
                _skippingButtonStage = false; break;
        }   
    }
    public void SetSkippingButtonStage()
    {
        _skippingButtonStage = true;
    }
    public void SetSkippingButtonNum(int skippingButtonNum)
    {
        _skippingButtonNum = skippingButtonNum;
    }
    
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
            if (_skippingButtonStage)
            {
                _dialogScenesManager.NextDialog(_skippingButtonNum);
                _effectsPlayer.PlaySpeech(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].PersonSpeech);
                return;
            }
            DialogEnded();
            return;
        }
        _currentPhraseIndex++;
        _futureText = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].Text;
        _dialogueManager.PlayMyDialogue(_futureText);
    }

}
