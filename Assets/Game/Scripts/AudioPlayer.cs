using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

public class AudioPlayer : MonoBehaviour
{
    private AudioSource _musicSource;

    [SerializeField] private AudioClip _musicClip;
    void Start()
    {
        _musicSource = AudioManager.Instance.PlayLoop(_musicClip, transform, 1f, 1f, true);
    }

}
