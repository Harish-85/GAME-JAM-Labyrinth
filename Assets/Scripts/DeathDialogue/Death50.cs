using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death50 : AbstractDialogueTrigger
{
    public override bool HasTriggered { get; set; } = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HasTriggered)
            return;
        if(PlayerDeathManager.DeathManager.totalDeaths >= 50)
        {
            HasTriggered = true;
        }
    }

}
