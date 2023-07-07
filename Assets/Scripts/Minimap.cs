using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;


public struct RoomMapData
{
    public MinimapRoom room;
    public GameObject mapHider;
}

public class Minimap : MonoBehaviour
{
    //singleton
    public static Minimap minimap;

    private void Awake()
    {
        if (minimap == null)
        {
            minimap = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
