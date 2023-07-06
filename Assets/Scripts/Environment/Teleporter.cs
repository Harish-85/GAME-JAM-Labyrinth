using System;
using UnityEngine;

//this is a teleporter what else do you want from me
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