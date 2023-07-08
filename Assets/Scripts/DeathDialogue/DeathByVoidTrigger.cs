using UnityEngine;

namespace DefaultNamespace
{
    public class DeathByVoidTrigger : AbstractDialogueTrigger
    {
        public override bool HasTriggered { get; set; } = false;

        private void Update()
        {
            if (HasTriggered)
                return;

            if ( PlayerDeathManager.DeathManager.deathByVoid != 0)
            {
                HasTriggered = true;
            }
            
        }
    }
    
}