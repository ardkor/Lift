using UnityEngine;
using UnityEngine.UI;

public class ButtonsManager : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private GameObject _dialogButton;
    [SerializeField] private GameObject _floorChoiceMenu;
/*    [SerializeField] private Button[] _floorButtons;
    [SerializeField] private Button _dialogButton;*/
    [SerializeField] private FloorUIButton[] _floorButtons;
    [SerializeField] private LightBulb[] _lightBulbs;
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
        EnableFloorChoiceMenu();
        TurnOnCurrentFloorButtons();
        TurnOnCurrentLightBulbs();
        DisableDialogButton();
    }

    public void DisableFloorButtonChoice()
    {
        DisableFloorChoiceMenu();
        TurnOffFloorButtons();
        TurnOffLightBulbs();
        EnableDialogButton();
    }
    private void EnableFloorChoiceMenu()
    {
        _floorChoiceMenu.SetActive(true);
    }
    private void DisableFloorChoiceMenu()
    {
        _floorChoiceMenu.SetActive(false);
    }
    private void TurnOnCurrentLightBulbs()
    {
        foreach (DialogScene.NextScene nextScene in _dialogScenesManager._currentScene.NextScenes)
        {
            foreach (LightBulb lightBulb in _lightBulbs)
            {
                if (lightBulb.Num - 1 == (int)nextScene.ButtonNum)
                {
                    lightBulb.SetActiveness(true);
                }
            }
        }
    }

    public void TurnOffLightBulbs()
    {
        foreach (LightBulb lightBulb in _lightBulbs)
        {
            lightBulb.SetActiveness(false);
        }
    }
    private void TurnOnCurrentFloorButtons()
    {
        foreach (DialogScene.NextScene nextScene in _dialogScenesManager._currentScene.NextScenes)
        {
            foreach (FloorUIButton button in _floorButtons)
            {
                if (button.Num - 1 == (int)nextScene.ButtonNum)
                {
                    button.SetActiveness(true);
                }
            }
            //_floorButtons[(int)nextScene.ButtonNum].interactable = true;
            //_floorButtons[(int)nextScene.ButtonNum].SetActiveness(true);
        }
    }

    public void TurnOffFloorButtons()
    {
        foreach (FloorUIButton button in _floorButtons)
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
