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
        [SerializeField] private string _name;
        [SerializeField] [TextArea(3, 5)] private string _text;
        //private enum PersonSpeech { Officer_low = 0, Detective_high = 10, Killer_high = 20 }
        //[Dropdown("Speech")] [SerializeField] private string _personSpeech;
        //private List<Person> Persons { get { return new List<Person>() { new Officer(), new Killer(), new Detective() }; } }
        private List<string> Speech { get { return new List<string>() { "Officer_mumbling_low", "Officer_mumbling_high", "Killer_mumbling_high", "Detective_mumbling_high", "sound_detective_wow" }; } }
        [Dropdown("Speech")] [SerializeField] private string personSpeech;

        private List<string> officerSprites { get { return new List<string>() { "Officer_1", "Officer_2" }; } }
        private List<string> detectiveSprites { get { return new List<string>() { "Detective_1", "Detective_2" }; } }
        private List<string> killerSprites { get { return new List<string>() { "Killer_1", "Killer_2" }; } }

        [Dropdown("officerSprites")] [SerializeField] private string officerSprite;
        [Dropdown("detectiveSprites")] [SerializeField] private string detectiveSprite;
        [Dropdown("killerSprites")] [SerializeField] private string killerSprite;

        [SerializeField] private bool _officerActive;
        [SerializeField] private bool _detectiveActive;
        [SerializeField] private bool _killerActive;

        [SerializeField] private float _officerPosX;
        [SerializeField] private float _officerPosY;

        [SerializeField] private float _detectivePosX;
        [SerializeField] private float _detectivePosY;

        [SerializeField] private float _killerPosX;
        [SerializeField] private float _killerPosY;

        public bool OfficerActive => _officerActive;
        public bool DetectiveActive => _detectiveActive;
        public bool KillerActive => _killerActive;

        public float OfficerPosX => _officerPosX;
        public float DetectivePosX => _detectivePosX;
        public float KillerPosX => _killerPosX;

        public float OfficerPosY => _officerPosY;
        public float DetectivePosY => _detectivePosY;
        public float KillerPosY => _killerPosY;

        // posxy и состояние вкл/выкл для каждой персоны, спрайт тоже для каждой свой - по 3 переменных
        public string Name => _name;

        public string PersonSpeech => personSpeech;
        public string OfficerSprite => officerSprite;
        public string DetectiveSprite => detectiveSprite;
        public string KillerSprite => killerSprite;
        public string Text => _text;
    }

    [SerializeField] private Phrase[] _phrases;
    public Phrase[] Phrases => _phrases;
}
