using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public bool MusicOn;
    [Min(0)]
    public float Volume;
    private AudioSource _audio;
    public AudioClip PlayerBounce;
    public AudioClip PlatfromBreak;
    public float VolumeScale;


    private void Awake()
    {
        MusicOn = true;
        _audio = GetComponent<AudioSource>();
    }


    private void OnDisable()
    {
        _audio.Stop();
    }

    void Update()
    {
        if (MusicOn)
            _audio.mute = false;
        else
            _audio.mute = true;
        AudioListener.volume = Volume;
    }

    public void PlayerBounceSound()
    {
        _audio.PlayOneShot(PlayerBounce, VolumeScale);
    }

    public void PlatformBreak()
    {
        _audio.PlayOneShot(PlatfromBreak, VolumeScale);
    }
}
