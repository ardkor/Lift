using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Killer : Person
{
    private List<string> Speech { get { return new List<string>() { "Killer_mumbling_high" }; } }

}
