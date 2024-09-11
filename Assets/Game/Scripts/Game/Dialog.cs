using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
[CreateAssetMenu(menuName = "Game/Data/" + nameof(Dialog))]
public class Dialog : ScriptableObject
{
/*    private class OfficerSpeech
    {
        private enum officerSpeech
        {
            Officer_low, Officer_high,
        }
    }*/
    [System.Serializable]
    public class Phrase
    {
       
        //private enum PersonSpeech { Officer_low = 0, Detective_high = 10, Killer_high = 20 }
        //[Dropdown("Speech")] [SerializeField] private string _personSpeech;
        //private List<Person> Persons { get { return new List<Person>() { new Officer(), new Killer(), new Detective() }; } }
        private List<string> Speech { get { return new List<string>() { "Officer_mumbling_low", "Officer_mumbling_high", "Killer_mumbling_high", "Detective_mumbling_high", "sound_detective_wow" }; } }
        private List<string> Sprites { get { return new List<string>() {"Officer_1", "Officer_2", "Detective_1", "Detective_2", "Killer_1", "Killer_2" }; } }
        [Dropdown("Speech")] [SerializeField] private string personSpeech;
        [Dropdown("Sprites")] [SerializeField] private string personSprite;
        [SerializeField] private string _name;
        [SerializeField][TextArea(3, 5)] private string _text;
        
        // posxy и состояние вкл/выкл для каждой персоны, спрайт тоже для каждой свой - по 3 переменных
        public string Name => _name;

        public string PersonSpeech => personSpeech;
        public string PersonSprite => personSprite;
        public string Text => _text;
    }

    [SerializeField] private Phrase[] _phrases;
    public Phrase[] Phrases => _phrases;
}
