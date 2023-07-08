using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

//If anyone asks who wrote this, it was me, I did it, I'm sorry.

[Serializable]
public enum FlagEnum
{
    FirstDarkRoom,
    FirstDeath,
    FirstShop,
    FirstDoor,
    FirstSpecialDoor,
    FirstGuppy
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
            if (f.AbstractDialogueTrigger.HasTriggered && !f.hasPreformedDialogue)
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
