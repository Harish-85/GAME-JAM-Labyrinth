
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocationBroadcaster : MonoBehaviour
{
    //singleton
    public static PlayerLocationBroadcaster Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector3 GetPlayerLocation()
    {
        return transform.position;
    }
    
}
