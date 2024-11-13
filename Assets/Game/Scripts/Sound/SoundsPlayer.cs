using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundsPlayer : MonoBehaviour
{
    [SerializeField] protected Sound[] _sounds;

    protected AudioClip _audioClip;
    protected AudioSource _audioSource;


    [System.Serializable]
    protected class Sound
    {
        public string name;
        public AudioClip audioClip;
    }
    public void TryPause()
    {
        if (_audioSource != null)
        {
            _audioSource.Pause();
        }
    }
    public void TryContinue()
    {
        if (_audioSource != null)
        {
            _audioSource.Play();//delayed?
        }
    }

   
}
