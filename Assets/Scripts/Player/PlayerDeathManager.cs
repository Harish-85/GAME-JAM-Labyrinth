using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
//More singletons
public class PlayerDeathManager : MonoBehaviour
{
    
    public static PlayerDeathManager DeathManager;
    
    private Vector3 spawnPoint;
    [SerializeField] private Transform player;
    [SerializeField] private Transform guppy;
    
     private Vector3 guppySpawnPoint;
    private void Awake()
    {
        if (DeathManager == null)
        {
            DeathManager = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = player.position;
        guppySpawnPoint = guppy.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDie()
    {
        DeathEffects();
        Invoke(nameof(AfterDeath), 1f);
        
    }

    private void AfterDeath()
    {
        player.position = spawnPoint;
        guppy.position = guppySpawnPoint;
        guppy.GetComponent<EnemyManager>().ResetSpeed();
        TimeManager.Instance.timePassed = 0;
    }


    void DeathEffects()
    {
        CameraVingnette.Instance.startVignette();
    }
    
}
