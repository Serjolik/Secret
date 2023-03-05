using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    // tracks delay
    public int newTrackDelay = 0;
    // souds clips
    public List<AudioClip> musicAudioClips = new List<AudioClip>();

    private AudioSource _musicAudioSource = null;

    private int _muted = 0;

    protected override void Awake()
    {
        // base singleton class awake
        base.Awake();

        _musicAudioSource = gameObject.AddComponent<AudioSource>();
    }
    void Start()
    {
        // music play
        StartCoroutine(PlayBackgroudMusic());
    }

    public void Mute()
    {   // muting misuc
        if (ReferenceEquals(Instance, null))
        {
            return;
        }

        if (Instance._muted == 0)
        {
            Instance._musicAudioSource.mute = true;
        }
        Instance._muted++;
    }

    public void TurnOn()
    {
        // �������� �� ��������� � ������ �� ������������� �������
        if (ReferenceEquals(Instance, null) || Instance._muted == 0)
        {
            return;
        }

        // �������� ����
        Instance._muted--;
        if (Instance._muted == 0)
        {
            Instance._musicAudioSource.mute = false;
        }

    }

    IEnumerator PlayBackgroudMusic()
    {
        int musicIndex = 0;

        while (musicAudioClips.Count > 0)
        {
            // ����� ��� ������� ���������� ����� + ��������
            float waitTime = musicAudioClips[musicIndex].length + newTrackDelay;
            // ����������� ������� ���� ���
            _musicAudioSource.PlayOneShot(musicAudioClips[musicIndex]);

            // ������ � ������� �������� �����
            musicIndex++;
            if (musicIndex >= musicAudioClips.Count)
            {
                musicIndex = 0;
            }

            // �������� ��� ��������� ���������� �����
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void SetVolume(float volume)
    {
        _musicAudioSource.volume = volume;
    }

}
