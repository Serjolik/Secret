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

    private void Update()
    {
        if (shakeTimer <= 0)
        {
            return;
        }

        shakeTimer -= Time.deltaTime;

        if (shakeTimer <= 0f)
        {
            //TIME IS OVER
            cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
        }
    }

}
