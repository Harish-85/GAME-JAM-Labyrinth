using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//If you are afraid of spiders then this script is for you
public class CreepyCrawlers : MonoBehaviour
{
    private ParticleSystem system;
    private AudioSource audioSource;
    [SerializeField] Vector2 spawnRange;
    [SerializeField] private float audioDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        system = GetComponent<ParticleSystem>();
        //generate a random time for the spiders to spawn each spawn should be atleast 5 minutes apart
        float randomTime = Random.Range(spawnRange.x, spawnRange.y);
        Invoke(nameof(SpawnSpiders), randomTime);
    }

    private void SpawnSpiders()
    {
        system.Play();
        float randomTime = Random.Range(spawnRange.x, spawnRange.y);
        Invoke(nameof(SpawnSpiders), randomTime);
        Invoke(nameof(PlayAudio), audioDelay);
    }
    private void PlayAudio()
    {
        audioSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
               
    }
}
