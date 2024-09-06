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
    [HideInInspector] public DialogScene _currentScene { get; private set; }

    private string branchIndex;
    private const string firstSceneIndex = "0";
    public void LoadFirstScene()
    {
        branchIndex = firstSceneIndex;
        InstallCurrentScene();
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
       // Debug.Log(branchIndex);
        _loadingScene = _beginScene;
        foreach(char c in branchIndex)
        {
           // Debug.Log(c);
            if (branchIndex == "0")
            {
               // Debug.Log(_loadingScene.BranchIndex);
                break;
            }
            //Debug.Log(_loadingScene.NextScenes.Length);
            for (int i = 0; i < _loadingScene.NextScenes.Length; ++i)
            {
                //Debug.Log("for");
                if (((int)_loadingScene.NextScenes[i].ButtonNum)+1.ToString()[0] == c)
                {
                    /*Debug.Log("if");
                    Debug.Log(((int)_loadingScene.NextScenes[i].ButtonNum).ToString()[0]);
                    Debug.Log(_loadingScene.NextScenes[i].DialogScene.BranchIndex);*/
                    _loadingScene = _loadingScene.NextScenes[i].DialogScene;
                   /* Debug.Log("loading");
                    Debug.Log(_loadingScene.BranchIndex);*/
                }
            }
        }
        _currentScene = _loadingScene;
       /* Debug.Log("current");
        Debug.Log(_currentScene.BranchIndex);*/
    }
    private void SaveScene() 
    {
        Debug.Log("saving");
        Debug.Log(_currentScene.BranchIndex);
        PlayerPrefs.SetString("CurrentSceneIndex", _currentScene.BranchIndex);
        //Debug.Log(PlayerPrefs.GetString("CurrentSceneIndex", "0"));
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
