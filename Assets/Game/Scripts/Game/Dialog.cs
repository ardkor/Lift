using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
[CreateAssetMenu(menuName = "Game/Data/" + nameof(Dialog))]
public class Dialog : ScriptableObject
{
    private class OfficerSpeech
    {
        private enum officerSpeech
        {
            Officer_low, Officer_high,
        }
    }
    [System.Serializable]
    public class Phrase
    {
        private List<string> Speech { get { return new List<string>() { "Officer_mumbling_low", "Officer_mumbling_high", "Detective_mumbling_high", "sound_detective_wow", "Killer_mumbling_high" }; } }
        //private enum PersonSpeech { Officer_low = 0, Detective_high = 10, Killer_high = 20 }
        [Dropdown("Speech")] [SerializeField] private string _personSpeech;

        [SerializeField] private string _name;
        [SerializeField][TextArea(3, 5)] private string _text;
        

        public string Name => _name;

        public string PersonSpeech => _personSpeech;
        public string Text => _text;
    }

    [SerializeField] private Phrase[] _phrases;
    public Phrase[] Phrases => _phrases;
}
