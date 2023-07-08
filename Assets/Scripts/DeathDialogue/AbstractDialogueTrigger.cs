using UnityEngine;

public abstract class AbstractDialogueTrigger:MonoBehaviour
{
    public abstract bool HasTriggered { get; set; }
}