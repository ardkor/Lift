using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Game/Data/" + nameof(DialogScene))]
public class DialogScene : ScriptableObject
{
    public enum ButtonNumber { first, second, third, forth};
    [SerializeField] private string _branchIndex;
    [SerializeField] private Dialog _dialog;

    public string BranchIndex => _branchIndex;
    public Dialog Dialog => _dialog;

    [System.Serializable]
    public class NextScene
    {
        //[SerializeField] private string _name;
        [SerializeField] private ButtonNumber _buttonNum;
        [SerializeField] private DialogScene _dialogScene;

        //public string Name => _name;
        public ButtonNumber ButtonNum => _buttonNum;
        public DialogScene DialogScene => _dialogScene;
    }

    [SerializeField] private NextScene[] _nextScenes;

    public NextScene[] NextScenes => _nextScenes;
}
