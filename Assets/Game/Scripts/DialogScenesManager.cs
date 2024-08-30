using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Data;

public class DialogScenesManager : MonoBehaviour
{
    [SerializeField] private Button _firstFloor;
    [SerializeField] private Button _secondFloor;
    [SerializeField] private Button _thirdFloor;
    [SerializeField] private Button _forthFloor;

    private DialogScene _currentScene;

    private void Awake()
    {
        //_firstFloor.onClick.AddListener(delegate { PlayDialogue1(); });
        
    }
}
