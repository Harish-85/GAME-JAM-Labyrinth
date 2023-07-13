using System;
using System.Collections;
using System.Collections.Generic;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (guppy.TryGetComponent(out EnemyManager enemyManager))
        {
            guppy.GetComponent<EnemyManager>().ResetSpeed();
        }
        if(SceneManager.GetActiveScene().buildIndex == 1)
            guppy.gameObject.SetActive(false);
        

        TimeManager.Instance.timePassed = 0;
        totalDeaths++;
        isDead = false;
    }

    public void ResetSpawnPoint(Vector3 playerPos, Vector3 guppyPos)
    {
        spawnPoint = playerPos;
        guppySpawnPoint = guppyPos;
    }
    
    void DeathEffects()
    {
        CameraVingnette.Instance.startVignette();
    }
    
}
