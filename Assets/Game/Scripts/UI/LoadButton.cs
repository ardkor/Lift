using UnityEngine;

public class LoadButton : MonoBehaviour
{
    [SerializeField] private DialogScenesManager _dialogScenesManager;

    public void LoadGame()
    {
        _dialogScenesManager.LoadCurrentScene();
    }
}
