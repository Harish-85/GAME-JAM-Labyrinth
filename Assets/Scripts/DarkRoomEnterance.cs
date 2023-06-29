using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(CustomTrigger))]
public class DarkRoomEnterance : MonoBehaviour
{
    private CustomTrigger trigger;

    [SerializeField] private Light2D playerLight;

    [SerializeField] private float maxLightRadius = 7f;

    [SerializeField] private float darkRoomLightRadius = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        trigger = GetComponent<CustomTrigger>();
        trigger.OnPlayerEnter += OnRoomEnter;
        trigger.OnPlayerExit += OnRoomExit;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnRoomEnter()
    {
        Debug.Log("Dark room entered");
        playerLight.pointLightOuterRadius = darkRoomLightRadius;
        LeanTween.value(playerLight.gameObject, playerLight.pointLightOuterRadius, 3, 2);

    }

    void OnRoomExit()
    {
        Debug.Log("Room Exit");
        
        playerLight.pointLightOuterRadius = maxLightRadius;
    }
}
