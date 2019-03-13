using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float shakeDuration = 0.3f;  //Time the camera shake effect will last
    [SerializeField] private float shakeAmplitude = 1.2f;
    [SerializeField] private float shakeFrequency = 2.0f;

    private float shakeElapsedTime = 0f;

    public CinemachineVirtualCamera virtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;

    // Start is called before the first frame update
    void Start()
    {
        if (virtualCamera != null)
            virtualCameraNoise =
                virtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
    }

    void Update()
    {
        ShakeCamera();
    }

    void ShakeCamera()
    {
        if (virtualCamera != null && virtualCameraNoise != null)
        {
            //if Camera shake effect is still playing
            if (shakeElapsedTime > 0)
            {
                //Set Cinemachine Camera Noise parameters
                virtualCameraNoise.m_AmplitudeGain = shakeAmplitude;
                virtualCameraNoise.m_FrequencyGain = shakeFrequency;

                //Update Shake Timer
                shakeElapsedTime -= Time.deltaTime;
            }
            else
            {
                //If camera shake effect is over, reset
                virtualCameraNoise.m_AmplitudeGain = 0f;
                shakeElapsedTime = 0f;
            }
        }
    }

    public void setDuration()
    {
        shakeElapsedTime = shakeDuration;
    }
}
