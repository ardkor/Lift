using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.Events;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    //[SerializeField] private TMP_Text _dialogText;
    [SerializeField] private SpeechPlayer _speechPlayer;
    [SerializeField] private EnvironmentPlayer _environmentPlayer;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private GameObject _endScreen;
    [SerializeField] private PersonsSpritesManager _personsSpritesManager;
    [SerializeField] private LiftManager _liftManager;
    [SerializeField] private List<PhraseConfig> _phraseConfigs;
    [SerializeField] private List<SoundConfig> _soundConfigs;
    [SerializeField] private List<BlackoutConfig> _blackoutConfigs;

    private string _futureText;
    private int _currentPhraseIndex;
    private bool _skippingButtonStage;
    private int _skippingButtonNum;
    private bool _prevLiftStatus;

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
        _prevLiftStatus = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].LiftOpenness;
        _liftManager.SetLiftSpriteStatus(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].LiftOpenness);
        //_futureText = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].Text; 
    }
    private void UpdateImages()
    {
        _personsSpritesManager.HideImages();
        foreach (PhraseConfig phraseConfig in _phraseConfigs)
        {
            if (_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].PhraseConfigName == phraseConfig.Name)
            {
                _personsSpritesManager.SetOfficerTransform(phraseConfig.OfficerPosition);
                _personsSpritesManager.SetDetectiveTransform(phraseConfig.DetectivePosition);
                _personsSpritesManager.SetKillerTransform(phraseConfig.KillerPosition);

                _personsSpritesManager.SetActivenessOfficer(phraseConfig.OfficerActive);
                _personsSpritesManager.SetActivenessDetective(phraseConfig.DetectiveActive);
                _personsSpritesManager.SetActivenessKiller(phraseConfig.KillerActive);

                _personsSpritesManager.SetOfficerSprite(phraseConfig.OfficerSprite);
                _personsSpritesManager.SetDetectiveSprite(phraseConfig.DetectiveSprite);
                _personsSpritesManager.SetKillerSprite(phraseConfig.KillerSprite);
            }
        }
        foreach (BlackoutConfig blackoutConfig in _blackoutConfigs)
        {
            if (_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].BlackoutConfigName == blackoutConfig.Name)
            {
                _personsSpritesManager.SetOfficerBlackout(blackoutConfig.OfficerDarkened);
                _personsSpritesManager.SetOfficerSize(blackoutConfig.OfficerSize);
                _personsSpritesManager.SetDetectiveBlackout(blackoutConfig.DetectiveDarkened);
                _personsSpritesManager.SetDetectiveSize(blackoutConfig.DetectiveSize);
                _personsSpritesManager.SetKillerBlackout(blackoutConfig.KillerDarkened);
                _personsSpritesManager.SetKillerSize(blackoutConfig.KillerSize);
            }
        }

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
        if (_prevLiftStatus != _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].LiftOpenness)
        {
            _liftManager.SwitchLiftStatus(_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].LiftOpenness);
            _prevLiftStatus = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].LiftOpenness;
        }
        UpdateImages();
        foreach (SoundConfig soundConfig in _soundConfigs)
        {
            if (_dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].SoundConfigName == soundConfig.Name) {
                _speechPlayer.Play(soundConfig.PersonSpeech);
                _environmentPlayer.Play(soundConfig.EnvironmentSound);
            }
        }
        _futureText = _dialogScenesManager._currentScene.Dialog.Phrases[_currentPhraseIndex].Text;
        _currentPhraseIndex++;
        _dialogueManager.PlayMyDialogue(_futureText);
    }

}
