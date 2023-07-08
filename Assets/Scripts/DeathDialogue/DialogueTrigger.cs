using System;
using UnityEngine;


//i miss unity collision detection
namespace DefaultNamespace
{
    [RequireComponent(typeof(CustomTrigger))]
    public class DialogueTrigger : AbstractDialogueTrigger
    {
        public override bool HasTriggered { get; set; } = false;
        private void Start()
        {
            GetComponent<CustomTrigger>().OnPlayerEnter += OnPlayerEnterOrExit;
            GetComponent<CustomTrigger>().OnPlayerExit += OnPlayerEnterOrExit;
        }
        
        void OnPlayerEnterOrExit()
        {
            HasTriggered = true;
        }
    }
}