using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesMaanger : MonoBehaviour
{
    //singleton
    public static SubtitlesMaanger SubtitlesManager;

    private void Awake()
    {
        if (SubtitlesManager == null)
        {
            SubtitlesManager = this;
        }
        else
        {
            Destroy(gameObject);
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
    
    void StartSubtitles(string text, float time)
    {
        StartCoroutine(ShowSubtitles(text, time));    
    }

    private IEnumerator ShowSubtitles(string text, float time)
    {
        
    }
}
