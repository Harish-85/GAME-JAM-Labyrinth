using System;
using UnityEngine;

namespace Environment
{
    
    public class Teleporter : MonoBehaviour,IInteractable
    {
        [SerializeField] private Transform teleportLocation;
        private CustomTrigger _trigger;
        public bool CanInteract { get; set; } = true;
        private void Start()
        {
            
        }

        public void OnInteract()
        {
            PlayerLocationBroadcaster.Instance.transform.position = teleportLocation.position;
        }

    }
}