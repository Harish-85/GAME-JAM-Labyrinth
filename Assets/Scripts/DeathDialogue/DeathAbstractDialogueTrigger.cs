using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class DeathAbstractDialogueTrigger: AbstractDialogueTrigger
    {
        public override bool HasTriggered { get; set; } = false;

        private void Update()
        {
            if (HasTriggered)
                return;

            if (PlayerDeathManager.DeathManager.deathByGuppy != 0 ||
                PlayerDeathManager.DeathManager.deathBySpikes != 0 || PlayerDeathManager.DeathManager.deathByVoid != 0)
            {
                HasTriggered = true;
            }
            
        }
    }
}