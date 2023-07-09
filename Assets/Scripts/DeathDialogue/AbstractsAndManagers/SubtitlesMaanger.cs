using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitlesMaanger : MonoBehaviour
{
    //singleton
    public static SubtitlesMaanger SubtitlesManager;
    
    [SerializeField] private TextMeshProUGUI subtitlesText;
    [SerializeField] private GameObject subtitleWindow;
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
    
    public void StartSubtitles(string text, float time)
    {
        ShowSubtitles(text);
        subtitleWindow.SetActive(true);
        Invoke(nameof(DisableSubtitles), time);
    }
    
    void DisableSubtitles()
    {
        subtitleWindow.SetActive(false);
    }
    void ShowSubtitles(string text)
    {
        
        subtitlesText.text = text;
    }
}
