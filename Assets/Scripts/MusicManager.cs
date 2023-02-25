using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : Singleton<MusicManager>
{
    // Задержка между треками
    public int newTrackDelay = 0;
    // Список треков
    public List<AudioClip> musicAudioClips = new List<AudioClip>();

    // Источник для проигрывания музыки
    private AudioSource _musicAudioSource = null;

    // Используется для отслеживания заглушения музыки
    private int _muted = 0;

    protected override void Awake()
    {
        // Настраиваем синглетон
        base.Awake();

        DontDestroyOnLoad(gameObject);

        // Добавляем компонент для проигрывания музыки
        _musicAudioSource = gameObject.AddComponent<AudioSource>();
    }
    void Start()
    {
        // Запускаем проигрывание музыки
        StartCoroutine(PlayBackgroudMusic());
    }

    // Заглушаем музыку
    public void Mute()
    {
        // Проверки для синглетона
        if (ReferenceEquals(Instance, null))
        {
            return;
        }

        // Если звук не заглушён
        if (Instance._muted == 0)
        {
            Instance._musicAudioSource.mute = true;
        }
        Instance._muted++;
    }

    // Возврат звука
    public void TurnOn()
    {
        // Проверка на синглетон и запрет на отрицательный счётчик
        if (ReferenceEquals(Instance, null) || Instance._muted == 0)
        {
            return;
        }

        // Включаем звук
        Instance._muted--;
        if (Instance._muted == 0)
        {
            Instance._musicAudioSource.mute = false;
        }

    }

    // Запуск следующего трека
    IEnumerator PlayBackgroudMusic()
    {
        // Текущий индекс трека
        int musicIndex = 0;
        // Проигрываем музыку, если она есть
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
