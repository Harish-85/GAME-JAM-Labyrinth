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

    public int totalDeaths = 0;
    public int deathByVoid = 0;
    public int deathByGuppy = 0;
    public int deathBySpikes = 0;
    
     private Vector3 guppySpawnPoint;
     private bool isDead = false;
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
        if(isDead)
            return;
        isDead = true;
        DeathEffects();
        Invoke(nameof(AfterDeath), 1f);
        
    }

    private void AfterDeath()
    {
        player.position = spawnPoint;
        guppy.position = guppySpawnPoint;
        guppy.GetComponent<EnemyManager>().ResetSpeed();
        guppy.gameObject.SetActive(false);
        TimeManager.Instance.timePassed = 0;
        totalDeaths++;
        isDead = false;
    }


    void DeathEffects()
    {
        CameraVingnette.Instance.startVignette();
    }
    
}
