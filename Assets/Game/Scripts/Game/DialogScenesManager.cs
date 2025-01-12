/*using System.Collections;
using System.Collections.Generic;*/
using UnityEngine;
//using UnityEngine.UI;


public class DialogScenesManager : MonoBehaviour
{
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private DialogScene _beginScene;
    [SerializeField] private ButtonsManager _buttonsManager;

    private DialogScene _loadingScene;
    //[HideInInspector] 
    public DialogScene _currentScene { get; private set; }

    private string branchIndex;
    private const string firstSceneIndex = "0";
    public void LoadFirstScene()
    {
        branchIndex = firstSceneIndex;
        InstallCurrentScene();
        SaveScene();
        _dialogManager.ClearTextCloud();
        _dialogManager.FirstPhrase();
    }
    public void LoadCurrentScene()
    {
        branchIndex = PlayerPrefs.GetString("CurrentSceneIndex", "0");
        InstallCurrentScene();
        _dialogManager.ClearTextCloud();
        _dialogManager.FirstPhrase();
    }
    private void InstallCurrentScene() 
    {
        _loadingScene = _beginScene;
        foreach(char c in branchIndex)
        {
            if (branchIndex == "0")
            {
                break;
            }
            for (int i = 0; i < _loadingScene.NextScenes.Length; ++i)
            {
                if (((int)_loadingScene.NextScenes[i].ButtonNum)+1.ToString()[0] == c)
                {
                    _loadingScene = _loadingScene.NextScenes[i].DialogScene;
                }
            }
        }
        _currentScene = _loadingScene;
    }
    private void SaveScene() 
    {
        PlayerPrefs.SetString("CurrentSceneIndex", _currentScene.BranchIndex);
    }

    public void NextDialog(int buttonNumber) 
    {
        buttonNumber--;
        foreach (DialogScene.NextScene nextScene in _currentScene.NextScenes)
        {
            if (buttonNumber == ((int)nextScene.ButtonNum))
            {
                _currentScene = nextScene.DialogScene;
                break;
            }
        }
        SaveScene();
        _buttonsManager.DisableFloorButtonChoice();
        _dialogManager.SetIndexToFirstPhase();
        if (_currentScene.NextScenes.Length == 1)
        {
            PlayerPrefs.SetInt("SkippingButtonStage", 1);
            PlayerPrefs.SetInt("SkippingButtonNum", (int)_currentScene.NextScenes[0].ButtonNum + 1);
            _dialogManager.SetSkippingButtonStage();
            _dialogManager.SetSkippingButtonNum((int)_currentScene.NextScenes[0].ButtonNum + 1);
        }
    }
}
