using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ChrisTutorials.Persistent;

public class DialogPlayer : SoundsPlayer
{
    private void FindClip(string name)
    {
        foreach (Sound sound in _sounds)
        {
            if (sound.name == name)
            {
                _audioClip = sound.audioClip;
                return;
            }
        }
    }
    public void Play(string name)
    {
        FindClip(name);
        if (_audioClip != null)
        {
            _audioSource = AudioManager.Instance.Play(_audioClip, transform, 1f, 1f);
        }
    }

}
