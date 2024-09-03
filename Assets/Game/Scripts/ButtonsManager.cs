using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private Button[] _floorButtons;
    [SerializeField] private Button _dialogButton;

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
        //Debug.Log("e");
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
            _floorButtons[(int)nextScene.ButtonNum].interactable = true;
        }
    }

    private void EnableDialogButton()
    {
        _dialogButton.gameObject.SetActive(true);
    }
    private void DisableDialogButton()
    {
        _dialogButton.gameObject.SetActive(false);
    }

private void Awake()
    {
        //_firstFloor.onClick.AddListener(delegate { PlayDialogue1(); });
    }

    public void TurnOffFloorButtons()
    {
        foreach (Button button in _floorButtons)
        {
            button.interactable = false;
        }
    }

    public void Test()
    {
        //TurnOnFloorButton(DialogScene.ButtonNumber.first);
    }

}
