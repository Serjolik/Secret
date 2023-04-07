using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    [Header("Params")]
    [SerializeField] private int newTrackDelay = 0;

    [Header("Background Musics")]
    public List<AudioClip> musicAudioClips = new List<AudioClip>();

    private AudioSource _musicAudioSource;

    private int _muted = 0;

    protected override void Awake()
    {
        base.Awake();
        _musicAudioSource = gameObject.GetComponent<AudioSource>();
    }
    void Start()
    {
        // music play
        StartCoroutine(PlayBackgroudMusic());
    }

    public void Mute()
    {
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
        if (ReferenceEquals(Instance, null) || Instance._muted == 0)
        {
            return;
        }

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
            // Время для запуска следующего трека + задержка
            float waitTime = musicAudioClips[musicIndex].length + newTrackDelay;
            // Проигрываем мелодию один раз
            _musicAudioSource.PlayOneShot(musicAudioClips[musicIndex]);

            // Работа с текущим индексом трека
            musicIndex++;
            if (musicIndex >= musicAudioClips.Count)
            {
                musicIndex = 0;
            }

            // Задержка для включения следующего трека
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void SetVolume(float volume)
    {
        _musicAudioSource.volume = volume;
    }

}
