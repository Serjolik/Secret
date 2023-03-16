using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance { get; private set; }

    [Header("Shake params")]
    [SerializeField] private float myShakeTime = 1f;
    [SerializeField] private float myIntensivity = 1f;

    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;

    private CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin;

    public bool shake;

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponentInChildren<CinemachineVirtualCamera>();

        cinemachineBasicMultiChannelPerlin = 
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float intensivity, float time)
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensivity;
        shakeTimer = time;
    }

    public void ShakeCamera() // this func need to test params in script
    {
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = myIntensivity;
        shakeTimer = myShakeTime;
    }

    private IEnumerator Shake()
    {
        float time = 0;
        ShakeCamera();
        while (time < shakeTimer)
        {
            time += Time.deltaTime;

            yield return null;
        }
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
    }

    private void Update()
    {
        if (shake)
        {
            shake = false;
            StartCoroutine(Shake());
        }
    }

}
