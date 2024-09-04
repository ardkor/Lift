using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

public class EffectsPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip[] _officerVoiceClips;
    [SerializeField] private AudioClip[] _detectiveVoiceClips;
    [SerializeField] private AudioClip[] _killerVoiceClips;

    private AudioClip _speechClip;

    //private AudioSource _speechSource;
    private void FindClip(string speech)
    {
        switch (speech)
        {
            case "Officer_mumbling_low":
                _speechClip = _officerVoiceClips[0]; break;
            case "Officer_mumbling_high":
                _speechClip = _officerVoiceClips[1]; break;
            case "Detective_mumbling_high":
                _speechClip = _detectiveVoiceClips[0]; break;
            default:
                break;
        }
    }
    public void PlaySpeech(string speech)
    {
        FindClip(speech);
        if (_speechClip != null) 
        {
            AudioManager.Instance.Play(_speechClip, transform, 1f, 1f);
        }
    }
   
}
