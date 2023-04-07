using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClips : Singleton<SoundClips>
{
    private AudioSource _musicAudioSource;

    [SerializeField] private AudioClip testClip;
    [SerializeField] private bool test;

    public List<AudioClip> walkingSoundClips;
    public List<AudioClip> runningSoundClips;

    protected override void Awake()
    {
        base.Awake();
        _musicAudioSource = GetComponent<AudioSource>();
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

    public void WalkingSound(int soundIndex)
    {
        if (_musicAudioSource.isPlaying)
        {
            return;
        }

        _musicAudioSource.PlayOneShot(walkingSoundClips[soundIndex]);
    }

    public void RunningSound(int soundIndex)
    {
        if (_musicAudioSource.isPlaying)
        {
            return;
        }

        _musicAudioSource.PlayOneShot(runningSoundClips[soundIndex]);
    }

}
