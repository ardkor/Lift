using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data : MonoBehaviour
{
    [SerializeField] private UIManager _uIManager;
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private GameObject _newGameConfirmationPanel;
    [SerializeField] private GameObject _mainMenuEnterConfirmationPanel;
    [SerializeField] private GameObject _exitConfirmationPanel;
    [SerializeField] private GameObject _settingsMenu;
    [SerializeField] private GameObject _pauseMenu;

    [SerializeField] private RectTransform _masterVolumeRect;
    [SerializeField] private RectTransform _musicVolumeRect;
    [SerializeField] private RectTransform _effectsVolumeRect;

    [SerializeField] private DialogScenesManager _dialogScenesManager;
    [SerializeField] private DialogManager _dialogManager;
    [SerializeField] private DialogueManager _dialogueManager;
    [SerializeField] private MainMenuNewGameButton _newGameButton;
    [SerializeField] private PauseCollider _pauseCollider;
    [SerializeField] private SpeechPlayer _speechPlayer;
    [SerializeField] private EnvironmentPlayer _environmentPlayer;
    [SerializeField] private MusicPlayer _musicPlayer;
    [SerializeField] private AudioPlayersManager _audioPlayersManager;

    [SerializeField] private AudioClip _buttonPushedClip;
    [SerializeField] private GameObject _buttonPushedSource;

    [SerializeField] private Sprite _pressedButton;
    [SerializeField] private Sprite _unpressedButton;
    [SerializeField] private Sprite _pressedListButton;
    [SerializeField] private Sprite _unpressedListButton;
    [SerializeField] private Sprite _pressedSliderButton;
    [SerializeField] private Sprite _unpressedSliderButton;
    [SerializeField] private Sprite _lightBulbOff;
    [SerializeField] private Sprite _lightBulbOn;

    public UIManager UIManager => _uIManager;
    public GameObject MainMenu => _mainMenu;
    public GameObject GameScreen => _gameScreen;
    public GameObject NewGameConfirmationPanel => _newGameConfirmationPanel;
    public GameObject MainMenuEnterConfirmationPanel => _mainMenuEnterConfirmationPanel;
    public GameObject ExitConfirmationPanel => _exitConfirmationPanel;
    public GameObject SettingsMenu => _settingsMenu;
    public GameObject PauseMenu => _pauseMenu;
    public RectTransform MasterVolumeRect => _masterVolumeRect;
    public RectTransform MusicVolumeRect => _musicVolumeRect;
    public RectTransform EffectsVolumeRect => _effectsVolumeRect;
    public DialogScenesManager DialogScenesManager => _dialogScenesManager;
    public DialogManager DialogManager => _dialogManager;
    public DialogueManager DialogueManager => _dialogueManager;
    public MainMenuNewGameButton NewGameButton => _newGameButton;
    public PauseCollider PauseCollider => _pauseCollider;
    public SpeechPlayer SpeechPlayer => _speechPlayer;
    public EnvironmentPlayer EnvironmentPlayer => _environmentPlayer;
    public MusicPlayer MusicPlayer => _musicPlayer;
    public AudioPlayersManager AudioPlayersManager => _audioPlayersManager;
    public AudioClip ButtonPushedClip => _buttonPushedClip;
    public GameObject ButtonPushedSource => _buttonPushedSource;


    public Sprite PressedButton => _pressedButton;
    public Sprite UnpressedButton => _unpressedButton;
    public Sprite PressedListButton => _pressedListButton;
    public Sprite UnpressedListButton => _unpressedListButton;
    public Sprite PressedSliderButton => _pressedSliderButton;
    public Sprite UnpressedSliderButton => _unpressedSliderButton;
    public Sprite LightBulbOff => _lightBulbOff;
    public Sprite LightBulbOn => _lightBulbOn;
}
