using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
//this is a nightmare to control in editor, but it works
public class DissappearingPlafroms : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    [SerializeField] private float dissappearTime;
    [SerializeField] private float activeTime;
    [SerializeField ]private GameObject platform;
    // Start is called before the first frame update
    void Start()
    {
        timepassed = offset;
    }

    private float timepassed;
    // Update is called once per frame
    void Update()
    {
        timepassed += Time.deltaTime;
        if (timepassed > dissappearTime
            )
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
