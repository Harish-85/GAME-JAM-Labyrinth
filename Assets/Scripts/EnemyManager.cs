using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using TarodevController;
using UnityEngine;
using UnityEngine.Events;

public class EnemyManager : MonoBehaviour
{

    [SerializeField]private float speed;
    [SerializeField]private float additionalSpeed;
    [SerializeField] private Transform enemyVisual;
    
    
    private AIDestinationSetter _destinationSetter;
    private AIPath _aiPath;

    private Vector3 _enemyScale;
    
    // Start is called before the first frame update
    void Start()
    {
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
       if (_aiPath.remainingDistance < 0.2f)
           PlayerDeathManager.DeathManager.OnDie();
   }
}
