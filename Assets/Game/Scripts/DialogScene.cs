using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(menuName = "Game/Data/" + nameof(DialogScene))]
    public class DialogScene : ScriptableObject
    {
        [HideInInspector] public enum ButtonNumber { first, second, third, forth};
        [SerializeField] string _BranchIndex;
        [SerializeField] private Dialog _dialog;

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
}