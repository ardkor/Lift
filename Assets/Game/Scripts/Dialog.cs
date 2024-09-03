using UnityEngine;


[CreateAssetMenu(menuName = "Game/Data/" + nameof(Dialog))]
public class Dialog : ScriptableObject
{
    [System.Serializable]
    public class Phrase
    {
        [SerializeField] private string _name;
        [SerializeField][TextArea(3, 5)] private string _text;
        //event
        public string Name => _name;
        public string Text => _text;
    }

    [SerializeField] private Phrase[] _phrases;
    public Phrase[] Phrases => _phrases;
}
