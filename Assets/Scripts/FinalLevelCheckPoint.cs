using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomTrigger))]
public class FinalLevelCheckPoint : MonoBehaviour
{
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private Transform guppySpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CustomTrigger>().OnPlayerEnter += OnPlayerEnter;
    }

    private void OnPlayerEnter()
    {
        PlayerDeathManager.DeathManager.ResetSpawnPoint(playerSpawnPoint.position, guppySpawnPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
