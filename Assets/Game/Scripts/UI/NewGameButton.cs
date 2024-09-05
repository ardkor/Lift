using UnityEngine;

public class NewGameButton : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    public void TryStartNewGame(GameObject confirmationPanel)
    {
        if (PlayerPrefs.HasKey("CurrentSceneIndex"))
        {
            confirmationPanel.SetActive(true);
        }
        else
        {
            StartNewGame();
        }
    }

    public void StartNewGame()
    {
        _gameScreen.SetActive(true);
        _dialogScenesManager.LoadFirstScene();
        _mainMenu.SetActive(false);
    }
}
