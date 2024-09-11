using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;

[System.Serializable]
public class Officer : Person
{
    private List<string> Speech { get { return new List<string>() { "Officer_mumbling_low", "Officer_mumbling_high" }; } }
    [Dropdown("Speech")] [SerializeField] public string personSpeech;
}
