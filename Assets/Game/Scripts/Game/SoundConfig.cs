using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Game/Data/" + nameof(SoundConfig))]
public class SoundConfig : ScriptableObject
{
    [SerializeField] private string _name;

    private List<string> _speech { get { return new List<string>() { "None", "Huh", "Killer_mumbling", "Killer_wow" }; } }
    [Dropdown("_speech")] [SerializeField] private string _personSpeech;

    private List<string> _environmentSounds { get { return new List<string>() { "None", "Knocking", "Knocking_aggro", "Steps" }; } }
    [Dropdown("_environmentSounds")] [SerializeField] private string _environmentSound;

    public string Name => _name;
    public string PersonSpeech => _personSpeech;
    public string EnvironmentSound => _environmentSound;
}
