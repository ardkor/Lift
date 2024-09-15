/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
using TMPro;
//using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    [SerializeField] private TMP_Text _dialogText;
    [SerializeField] private SpeechPlayer _effectsPlayer;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private PersonsSpritesManager _personsSpritesManager;

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
        _skippingButtonNum = PlayerPrefs.GetInt("SkippingButtonNum", 0);
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
    public void ClearTextCloud()
    {
        //Debug.Log("Clear");
        //_dialogText.text = string.Empty;
        _dialogueManager.PlayMyDialogue("");//(string.Empty);
        _dialogueManager.trySkipToEndOfCurrentMessage();
/*        _dialogText.gameObject.SetActive(false);
        _dialogText.gameObject.SetActive(true);*/
    }
    public void FirstPhrase()
    {
        _currentPhraseIndex = 0;
        UpdateImages();

        //_futureText = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].Text; 
    }
    private void UpdateImages() 
    {
        _personsSpritesManager.HideImages();
        //установить позиции 
        _personsSpritesManager.SetActivenessOfficer(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].OfficerActive);
        _personsSpritesManager.SetActivenessDetective(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].DetectiveActive);
        _personsSpritesManager.SetActivenessKiller(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].KillerActive);
        //if (_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].OfficerSprite == 
        _personsSpritesManager.SetOfficerSprite(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].OfficerSprite);
        _personsSpritesManager.SetDetectiveSprite(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].DetectiveSprite);
        _personsSpritesManager.SetKillerSprite(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].KillerSprite);
    }
    public void NextPhrase()
    {

        if (_dialogueManager.trySkipToEndOfCurrentMessage()) // #testThis
        {
            return;
        }
        if (_currentPhraseIndex == _dialogScenesManager._currentScene.Dialog.Phrases.Length)
        {
            if (_skippingButtonStage)
            {
                _dialogScenesManager.NextDialog(_skippingButtonNum);
                //Debug.Log(_skippingButtonNum);
                _skippingButtonStage = false;
                _skippingButtonNum = 0;
                PlayerPrefs.SetInt("SkippingButtonStage", 0);
                PlayerPrefs.SetInt("SkippingButtonNum", 0);
                NextPhrase();
                return;
            }
            if (_dialogScenesManager._currentScene.NextScenes.Length == 0)
            {
                _endScreen.gameObject.SetActive(true);
                return;
            }
            DialogEnded();
            return;
        }
        UpdateImages();
        _effectsPlayer.PlaySpeech(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].PersonSpeech);
        
        _futureText = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].Text;
        _currentPhraseIndex++;
        _dialogueManager.PlayMyDialogue(_futureText);
    }

}
