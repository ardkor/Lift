using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
[CreateAssetMenu(menuName = "Game/Data/" + nameof(Dialog))]
public class Dialog : ScriptableObject
{
    [System.Serializable]
    public class Phrase
    {
        private List<string> _Speakers { get { return new List<string>() { "Оффицер:", "Убийца:", "Детектив:"}; } }
        [Dropdown("_Speakers")] [SerializeField] private string _speaker;

        [SerializeField] [TextArea(3, 5)] private string _text;

        private List<string> _blackoutConfigNames { get { return new List<string>() { "OnlyOfficer", "OnlyKiller", "OnlyDetective" }; } }
        [Dropdown("_blackoutConfigNames")] [SerializeField] private string _blackoutConfigName;
        private List<string> _phraseConfigNames { get { return new List<string>() { "O1", "K1", "D1", "KO1", "DK1", "DKO1" }; } }
        [Dropdown("_phraseConfigNames")] [SerializeField] private string _phraseConfigName;
        private List<string> _soundConfigNames { get { return new List<string>() { "None", "Huh", "Killer_mumbling", "Killer_wow", "Knocking", "Knocking_aggro", "Steps" }; } }
        [Dropdown("_soundConfigNames")] [SerializeField] private string _soundConfigName;

        [SerializeField] private bool _liftOpenness;

        public string Speaker => _speaker;
        public string Text => _text;

        public string BlackoutConfigName => _blackoutConfigName;
        public string PhraseConfigName => _phraseConfigName;
        public string SoundConfigName => _soundConfigName;
        public bool LiftOpenness => _liftOpenness;

    }

    [SerializeField] private Phrase[] _phrases;
    public Phrase[] Phrases => _phrases;
}
