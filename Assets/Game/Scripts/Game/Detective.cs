using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Detective : Person
{
    private List<string> Speech { get { return new List<string>() {"Detective_mumbling_high", "sound_detective_wow" }; } }

}
