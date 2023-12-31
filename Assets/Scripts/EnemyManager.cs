using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

//His name is GUPPY
public class EnemyManager : MonoBehaviour
{

    [SerializeField]private float speed;
    [SerializeField]private float additionalSpeed;
    [SerializeField] private Transform enemyVisual;

    private float initialSpeed;
    
    private AIDestinationSetter _destinationSetter;
    private AIPath _aiPath;

    private Vector3 _enemyScale;
    
    // Start is called before the first frame update
    void Start()
    {
        initialSpeed = speed;
        _aiPath = GetComponent<AIPath>();
        _destinationSetter = GetComponent<AIDestinationSetter>();
        _enemyScale = enemyVisual.localScale;
        GetComponent<AIPath>().maxSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        _destinationSetter.target = PlayerLocationBroadcaster.Instance.transform;
        _aiPath.maxSpeed  =speed + additionalSpeed * TimeManager.Instance.timePassed/TimeManager.Instance.totalTime;
        
        if (Vector2.Dot(_aiPath.velocity, Vector2.right) > 0)
        {
            enemyVisual.localScale = new Vector3(-_enemyScale.x, _enemyScale.y, _enemyScale.z);
        }
        else
        {
            enemyVisual.localScale = new Vector3(_enemyScale.x, _enemyScale.y, _enemyScale.z);
        }
        playerKillCheck();
    }

    void playerKillCheck()
    {
        if (_aiPath.remainingDistance < 2f)
        {
            PlayerDeathManager.DeathManager.OnDie();
            PlayerDeathManager.DeathManager.deathByGuppy++;
        }
    }

    public void ResetSpeed()
   {
       _aiPath.maxSpeed = initialSpeed;
       speed = initialSpeed;
   }
}
