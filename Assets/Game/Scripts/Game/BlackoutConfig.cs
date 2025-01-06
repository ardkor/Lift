using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;

[CreateAssetMenu(menuName = "Game/Data/" + nameof(BlackoutConfig))]
public class BlackoutConfig : ScriptableObject
{
    [SerializeField] private string _name;

    [SerializeField] private bool _officerDarkened;
    [SerializeField] private bool _killerDarkened;
    [SerializeField] private bool _detectiveDarkened;

    [SerializeField] private float _officerSize;
    [SerializeField] private float _killerSize;
    [SerializeField] private float _detectiveSize;

    public string Name => _name;
    public bool OfficerDarkened => _officerDarkened;
    public bool KillerDarkened => _killerDarkened;
    public bool DetectiveDarkened => _detectiveDarkened;

    public float OfficerSize => _officerSize;
    public float KillerSize => _killerSize;
    public float DetectiveSize => _detectiveSize;

}
