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
        private List<string> Speech { get { return new List<string>() { "Officer_mumbling_low", "Officer_mumbling_high", "Killer_mumbling_high", "Detective_mumbling_high", "sound_detective_wow" }; } }
        [Dropdown("Speech")] [SerializeField] private string personSpeech;

        [SerializeField] private bool _officerActive;
        [SerializeField] private bool _detectiveActive;
        [SerializeField] private bool _killerActive;
        private List<string> _officerSprites { get { return new List<string>() { "Officer_1"}; } }
        private List<string> _detectiveSprites { get { return new List<string>() { "Detective_1"}; } }
        private List<string> _killerSprites { get { return new List<string>() { "Killer_1", "Killer_2" }; } }

        [Dropdown("_officerSprites")] [EnableIf("OfficerActive")] [SerializeField] private string _officerSprite;
        [Dropdown("_detectiveSprites")] [EnableIf("DetectiveActive")] [SerializeField] private string _detectiveSprite;
        [Dropdown("_killerSprites")] [EnableIf("KillerActive")] [SerializeField] private string _killerSprite;

        [EnableIf("OfficerActive")] [AllowNesting] [SerializeField] private bool _officerFlip;
        [EnableIf("DetectiveActive")] [AllowNesting] [SerializeField] private bool _detectiveFlip;
        [EnableIf("KillerActive")] [AllowNesting] [SerializeField] private bool _killerFlip;

        private List<string> _officerPositions { get { return new List<string>() { "Officer_position_1"}; } }
        private List<string> _detectivePositions { get { return new List<string>() { "Detective_position_1"}; } }
        private List<string> _killerPositions { get { return new List<string>() { "Killer_position_1"}; } }

        [Dropdown("_officerPositions")] [EnableIf("OfficerActive")] [SerializeField] private string _officerPosition;
        [Dropdown("_detectivePositions")] [EnableIf("DetectiveActive")] [SerializeField] private string _detectivePosition;
        [Dropdown("_killerPositions")] [EnableIf("KillerActive")] [SerializeField] private string _killerPosition;

        [SerializeField] private bool _liftOpenness;

        [SerializeField] private List<Sound> _sounds;

        public string Name => _name;
        public string Text => _text;

        public bool OfficerActive => _officerActive;
        public bool DetectiveActive => _detectiveActive;
        public bool KillerActive => _killerActive;

        public bool OfficerFlip => _officerFlip;
        public bool DetectiveFlip => _detectiveFlip;
        public bool KillerFlip => _killerFlip;

        public string OfficerSprite => _officerSprite;
        public string DetectiveSprite => _detectiveSprite;
        public string KillerSprite => _killerSprite;

        public string OfficerPosition => _officerPosition;
        public string DetectivePosition => _detectivePosition;
        public string KillerPosition => _killerPosition;

        public bool LiftOpenness => _liftOpenness;
        public string PersonSpeech => personSpeech;
        

        [System.Serializable]
        public class Sound
        {
            [SerializeField] private AudioClip _audioClip;
            [SerializeField] private int _delay;

            public AudioClip AudioClip => _audioClip;
            public int Delay => _delay;
        }
        public List<Sound> Sounds => _sounds;
    }

    [SerializeField] private Phrase[] _phrases;
    public Phrase[] Phrases => _phrases;
}
