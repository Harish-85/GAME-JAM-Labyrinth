using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

//To the person that has motion sickness. I am not adding a setting to remove this
namespace DefaultNamespace
{
    public class CameraShake : MonoBehaviour
    {
        private CinemachineVirtualCamera virtualCamera;

        //singleton again
        public static CameraShake Instance;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
        }
        
        private void Start()
        {
            virtualCamera = GetComponent<CinemachineVirtualCamera>();
        }


        public void Shake(float duration, float magnitude)
        {
            StartCoroutine(ShakeCoroutine(duration, magnitude));
        }

        private IEnumerator ShakeCoroutine(float duration, float magnitude)
        {
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = magnitude;
            yield return new WaitForSeconds(duration);
            virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0;
            
        }    
    }
}