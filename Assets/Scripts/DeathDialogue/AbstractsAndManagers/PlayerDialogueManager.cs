using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

//If anyone asks who wrote this, it was me, I did it, I'm sorry.

[Serializable]
public enum FlagEnum
{
    deaths_10,
    deaths_30,
    deaths_50,
    first_death,
    first_blinking_platform,
    first_squishy_death,
    first_guppy_death,
    first_void_death,
    first_dark_room,
    first_shop,
    teleporterUnlock,
    randomStory1,
    randomStory2,
    randomStory3
}

[Serializable]
public class Flag
{
    public FlagEnum flag;
    public AbstractDialogueTrigger AbstractDialogueTrigger;
    public AudioClip audio;
    public bool hasPreformedDialogue;
}


//this class is a fucking mess.
public class PlayerDialogueManager : MonoBehaviour
{
    [SerializeField] private List<Flag> flags;
    public static PlayerDialogueManager Instance;
    private AudioSource _source;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
    }

    private void Start()
    {
        _source = GetComponent<AudioSource>();
    }


    public void PlayLatestFlag()
    {
        //check for the first flag that is true and has performed is false
        foreach (Flag f in flags)
        {
            if (f.AbstractDialogueTrigger.HasTriggered && !f.hasPreformedDialogue && !_source.isPlaying)
            {
                f.hasPreformedDialogue = true;
                PerformDialogue(f.audio);
                return;
            }
        }
    }

    void PerformDialogue(AudioClip clip)
    {
        _source.clip = clip;
        _source.Play();
    }
    
    
    
}
