using UnityEngine;

public class LoadGameButton : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;

    public void LoadGame()
    {
        _dialogScenesManager.LoadCurrentScene();
    }
}
