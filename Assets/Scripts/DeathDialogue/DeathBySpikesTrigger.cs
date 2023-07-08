using UnityEngine;

namespace DefaultNamespace
{
    public class DeathBySpikesTrigger : AbstractDialogueTrigger
    {
        public override bool HasTriggered { get; set; } = false;

        private void Update()
        {
            if (HasTriggered)
                return;

            if (PlayerDeathManager.DeathManager.deathBySpikes != 0 )
            {
                HasTriggered = true;
            }
            
        }
    
    }
}