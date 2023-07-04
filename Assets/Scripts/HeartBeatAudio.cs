using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class HeartBeatAudio : MonoBehaviour
    {
        private AudioSource audioSource;

        [SerializeField] private Transform enemy;
        
        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void Update()
        {
            float clamp = Mathf.Clamp(20 / Vector2.Distance(transform.position, enemy.position), .2f, 1.8f);
            audioSource.pitch = clamp;
        }
    }
}