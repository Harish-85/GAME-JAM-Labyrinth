using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenPathway : MonoBehaviour
{

    [SerializeField] private GameObject hiddenLevel;

    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<CustomTrigger>().OnPlayerEnter += (OnCustomTriggerEnter);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCustomTriggerEnter()
    {
        Debug.Log("Hidden level triggered");
        hiddenLevel.SetActive(true);
    }
}
