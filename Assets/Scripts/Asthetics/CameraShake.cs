using System;
using System.Collections;
using Cinemachine;
using UnityEngine;

namespace DefaultNamespace
{
    public class CameraShake : MonoBehaviour
    {
        private CinemachineVirtualCamera virtualCamera;

        //singleton
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