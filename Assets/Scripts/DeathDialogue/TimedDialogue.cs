using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TimedDialogue : AbstractDialogueTrigger
{
    public override bool HasTriggered { get; set; } = false;
[SerializeField] private Vector2 timeRange;
    private float time;
    private void Start()
    {
        time = Random.Range(timeRange.x, timeRange.y);
        Invoke(nameof(SetTrigger), time);
    }

    void SetTrigger()
    {
        HasTriggered = true;
    }
}
