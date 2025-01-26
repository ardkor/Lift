using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenuContinueGameButton : UIButton
{
    private GameObject _mainMenu;
    private GameObject _gameScreen;
    private DialogScenesManager _dialogScenesManager;


    override protected void OnEnable()
    {
        if (!PlayerPrefs.HasKey("CurrentSceneIndex"))
        {
            gameObject.SetActive(false);
            //base.
        }
    }

    override protected void Start()
    {
        StartButton();
        _mainMenu = _uiData.Data.MainMenu;
        _gameScreen = _uiData.Data.GameScreen;
        _dialogScenesManager = _uiData.Data.DialogScenesManager;
    }
    public override void DoOnPointerDown()
    {
        base.DoOnPointerDown();
    }
    public override void OnPointerUp(PointerEventData eventData)
    {
        DoOnPointerUp();
    }
    public override void DoOnPointerUp()
    {
        base.DoOnPointerUp();
        ContinueGame();
    }
    public void ContinueGame()
    {
        _gameScreen.SetActive(true);
        _dialogScenesManager.LoadCurrentScene();
        _mainMenu.SetActive(false);
    }

}
