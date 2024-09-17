using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private GameObject _dialogButton;
/*    [SerializeField] private Button[] _floorButtons;
    [SerializeField] private Button _dialogButton;*/
    [SerializeField] private FloorButton[] _floorButtons;
    private void OnEnable()
    {
        _dialogManager.DialogEnded += EnableFloorButtonChoice;
        // _dialogManager.DialogEnded += NextDialog;
    }
    private void OnDisable()
    {
        _dialogManager.DialogEnded -= EnableFloorButtonChoice;
        //_dialogManager.DialogEnded -= NextDialog;
    }

    private void EnableFloorButtonChoice()
    {
        TurnOnCurrentFloorButtons();
        DisableDialogButton();
    }

    public void DisableFloorButtonChoice()
    {
        TurnOffFloorButtons();
        EnableDialogButton();
    }
    private void TurnOnCurrentFloorButtons()
    {
        foreach (DialogScene.NextScene nextScene in _dialogScenesManager._currentScene.NextScenes)
        {
            //_floorButtons[(int)nextScene.ButtonNum].interactable = true;
            _floorButtons[(int)nextScene.ButtonNum].SetActiveness(true);
        }
    }

    public void TurnOffFloorButtons()
    {
        foreach (FloorButton button in _floorButtons)
        {
            button.SetActiveness(false); 
        }
        /*foreach (Button button in _floorButtons)
        {
            button.interactable = false;
        }*/
    }
    private void EnableDialogButton()
    {
        _dialogButton.gameObject.SetActive(true);
    }
    private void DisableDialogButton()
    {
        _dialogButton.gameObject.SetActive(false);
    }


}
