using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class CustomTrigger : MonoBehaviour
{
    private BoxCollider2D _collider2D;
    public event UnityAction OnPlayerEnter;
    public event UnityAction OnPlayerExit;
    
    private bool isPlayerInside = false;
    // Start is called before the first frame update
    void Start()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        ScaleCheck();
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInside && !IsPlayerInside())
        {
            isPlayerInside = false;
            OnPlayerExit?.Invoke();
            Debug.Log("Player exited");
        }
        else if(!isPlayerInside && IsPlayerInside())
        {
            isPlayerInside = true;
            OnPlayerEnter?.Invoke();
            Debug.Log("Player entered");
        }
        
        
     
    }

    void ScaleCheck()
    {
        if (transform.localScale != Vector3.one)
        {
            Debug.LogWarning(transform.name + " Scale is not 1,1,1 this will mess up the trigger collider");
        }
    }
    
    //check if the player is inside the trigger
    bool IsPlayerInside()
    {
        Transform player = PlayerLocationBroadcaster.Instance.transform;
        Vector2 playerPos = player.position;
        Vector2 playerSize = player.GetComponent<BoxCollider2D>().size;
        Vector2 playerMin = playerPos - playerSize / 2;
        Vector2 playerMax = playerPos + playerSize / 2;
        Vector2 triggerPos = transform.position + new Vector3(_collider2D.offset.x,_collider2D.offset.y,0);
        Vector2 triggerSize = _collider2D.size;
        Vector2 triggerMin = triggerPos - triggerSize / 2;
        Vector2 triggerMax = triggerPos + triggerSize / 2;
        return playerMin.x < triggerMax.x && playerMax.x > triggerMin.x &&
               playerMin.y < triggerMax.y && playerMax.y > triggerMin.y;
    }
    
}
