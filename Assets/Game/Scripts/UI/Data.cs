using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _confirmationPanel;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private DialogScenesManager _dialogScenesManager;

    [SerializeField] private Sprite _pressedButton;
    [SerializeField] private Sprite _unpressedButton;
    [SerializeField] private Sprite _pressedListButton;
    [SerializeField] private Sprite _unpressedListButton;
    [SerializeField] private Sprite _pressedSliderButton;
    [SerializeField] private Sprite _unpressedSliderButton;

    public UIManager UIManager => _uIManager;
    public GameObject MainMenu => _mainMenu;
    public GameObject GameScreen => _gameScreen;
    public GameObject ConfirmationPanel => _confirmationPanel;
    public GameObject SettingsMenu => _settingsMenu;
    public DialogScenesManager DialogScenesManager => _dialogScenesManager;
    public Sprite PressedButton => _pressedButton;
    public Sprite UnpressedButton => _unpressedButton;
    public Sprite PressedListButton => _pressedListButton;
    public Sprite UnpressedListButton => _unpressedListButton;
    public Sprite PressedSliderButton => _pressedSliderButton;
    public Sprite UnpressedSliderButton => _unpressedSliderButton;
}
