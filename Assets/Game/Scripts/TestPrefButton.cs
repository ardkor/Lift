using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrefButton : MonoBehaviour
{
    public void OnPress()
    {
        PlayerPrefs.SetInt("testInt", PlayerPrefs.GetInt("testInt", 0) + 1);
        Debug.Log(PlayerPrefs.GetInt("testInt", 0));
    }
}
