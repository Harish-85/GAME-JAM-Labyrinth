using System;
using UnityEngine;

//I just learnt what pitch is so I am using it
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