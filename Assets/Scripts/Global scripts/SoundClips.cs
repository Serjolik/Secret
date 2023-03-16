using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClips : Singleton<SoundClips>
{
    private AudioSource _musicAudioSource;

    [SerializeField] private AudioClip testClip;
    [SerializeField] private bool test;

    protected override void Awake()
    {
        base.Awake();
        _musicAudioSource = GetComponentInParent<AudioSource>();
    }

    private void Update()
    {
        if (test)
        {
            test = false;
            PlayClip(testClip);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        _musicAudioSource.PlayOneShot(clip);
    }
}
