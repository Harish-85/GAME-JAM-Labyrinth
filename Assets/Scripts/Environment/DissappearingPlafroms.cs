using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
//this is a nightmare to control in editor, but it works
public class DissappearingPlafroms : MonoBehaviour
{
    [SerializeField] private float offset = 0;
    [SerializeField] private float dissappearTime;
    [SerializeField] private float activeTime;
    [SerializeField ]private GameObject platform;

    [SerializeField] private SpriteRenderer platformSprite;

    private Color col;
    // Start is called before the first frame update
    void Start()
    {
        timepassed = offset;
        col = platformSprite.color;
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
        
        //IF THE PLATFORM IS ABOUT TO DISSAPPPEAR REDUCE OPACITY
        if (timepassed > dissappearTime - .2f)
        {
            Color c = col - new Color(0, 0, 0, .9f);
            LeanTween.value(platform, platformSprite.color, c, .2f).setOnUpdate((val) => { platformSprite.color = val;});
        }
        else
        {
            platformSprite.color = col;
        }
    }
}
