using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ContinueGameButton : UIButton
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private DialogScenesManager _dialogScenesManager;


    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("CurrentSceneIndex"))
        {
            gameObject.SetActive(false);
            //base.
        }
    }

    private void Start()
    {
        StartButton();
        _mainMenu = _buttonData.Data.MainMenu;
        _gameScreen = _buttonData.Data.GameScreen;
        _dialogScenesManager = _buttonData.Data.DialogScenesManager;
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        ContinueGame();
    }
    public void ContinueGame()
    {
        _gameScreen.SetActive(true);
        _dialogScenesManager.LoadCurrentScene();
        _mainMenu.SetActive(false);
    }

}
