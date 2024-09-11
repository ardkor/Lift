using UnityEngine;
using ChrisTutorials.Persistent;

public class MusicPlayer : MonoBehaviour
{
    private AudioSource _musicSource;

    [SerializeField] private AudioClip _musicClip;
    void Start()
    {
        _musicSource = AudioManager.Instance.PlayLoop(_musicClip, transform, 1f, 1f, true);
    }

}
