using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
[CreateAssetMenu(menuName = "Game/Data/" + nameof(PhraseConfig))]
public class PhraseConfig : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private bool _officerActive;
    [SerializeField] private bool _detectiveActive;
    [SerializeField] private bool _killerActive;
    private List<string> _officerSprites { get { return new List<string>() { "Officer_1" }; } }
    private List<string> _detectiveSprites { get { return new List<string>() { "Detective_1" }; } }
    private List<string> _killerSprites { get { return new List<string>() { "Killer_1", "Killer_2" }; } }

    [Dropdown("_officerSprites")] [EnableIf("OfficerActive")] [SerializeField] private string _officerSprite;
    [Dropdown("_detectiveSprites")] [EnableIf("DetectiveActive")] [SerializeField] private string _detectiveSprite;
    [Dropdown("_killerSprites")] [EnableIf("KillerActive")] [SerializeField] private string _killerSprite;

    [EnableIf("OfficerActive")] [AllowNesting] [SerializeField] private bool _officerFlip;
    [EnableIf("DetectiveActive")] [AllowNesting] [SerializeField] private bool _detectiveFlip;
    [EnableIf("KillerActive")] [AllowNesting] [SerializeField] private bool _killerFlip;

    private List<string> _officerPositions { get { return new List<string>() { "Officer_position_1", "Officer_position_center", "Officer_position_pair_left", "Officer_position_triple" }; } }
    private List<string> _detectivePositions { get { return new List<string>() { "Detective_position_1", "Detective_position_center", "Detective_position_pair_right", "Detective_position_triple" }; } }
    private List<string> _killerPositions { get { return new List<string>() { "Killer_position_1", "Killer_position_center", "Killer_position_pair_left", "Killer_position_pair_right", "Killer_position_triple" }; } }

    [Dropdown("_officerPositions")] [EnableIf("OfficerActive")] [SerializeField] private string _officerPosition;
    [Dropdown("_detectivePositions")] [EnableIf("DetectiveActive")] [SerializeField] private string _detectivePosition;
    [Dropdown("_killerPositions")] [EnableIf("KillerActive")] [SerializeField] private string _killerPosition;


    public string Name => _name;
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
}
