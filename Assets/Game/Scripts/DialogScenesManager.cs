using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DialogScenesManager : MonoBehaviour
{
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private DialogScene _beginScene;
    [SerializeField] private ButtonsManager _buttonsManager;

    private DialogScene _loadingScene;
    [HideInInspector] public DialogScene _currentScene { get; private set; }

    private string branchIndex;

    private void LoadScene() 
    {
        _loadingScene = _beginScene;
        branchIndex = PlayerPrefs.GetString("CurrentSceneIndex", "0");
        foreach(char c in branchIndex)
        {
            if (branchIndex == "0")
            {
                break;
            }
            for (int i = 0; i < _loadingScene.NextScenes.Length; ++i)
            {
                if(_loadingScene.NextScenes[i].ButtonNum.ToString()[0] == c)
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

    public void NewGame()
    {
        _currentScene = _beginScene;
        _dialogManager.FirstPhrase();
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
    }
}
