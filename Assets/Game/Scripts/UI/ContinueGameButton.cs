using UnityEngine;

public class ContinueGameButton : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    [SerializeField] private GameObject _gameScreen;
    [SerializeField] private DialogScenesManager _dialogScenesManager;
    private void OnEnable()
    {
        if (!PlayerPrefs.HasKey("CurrentSceneIndex"))
        {
            gameObject.SetActive(false);
        }
    }
    public void ContinueGame()
    {
        _gameScreen.SetActive(true);
        _dialogScenesManager.LoadCurrentScene();
        _mainMenu.SetActive(false);
    }

}
