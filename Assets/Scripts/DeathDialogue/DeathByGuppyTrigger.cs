using UnityEngine;

namespace DefaultNamespace
{
    public class DeathByGuppyTrigger : AbstractDialogueTrigger
    {
        public override bool HasTriggered { get; set; } = false;

        private void Update()
        {
            if (HasTriggered)
                return;

            if (PlayerDeathManager.DeathManager.deathByGuppy != 0 )
            {
                HasTriggered = true;
            }
            
        }
    
    }
}