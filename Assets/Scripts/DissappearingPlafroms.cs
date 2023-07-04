using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class DissappearingPlafroms : MonoBehaviour
{
    [SerializeField] private float dissappearTime;
    [SerializeField] private float activeTime;
    [SerializeField ]private GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private float timepassed = 0;
    // Update is called once per frame
    void Update()
    {
        timepassed += Time.deltaTime;
        if (timepassed > dissappearTime)
        {
            platform.SetActive(false);
        }
        if (timepassed > dissappearTime + activeTime)
        {
            platform.SetActive(true);
            timepassed = 0;
        }
    }
}
