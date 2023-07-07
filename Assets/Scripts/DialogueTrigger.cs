using System;
using UnityEngine;

//i miss unity collision detection
namespace DefaultNamespace
{
    [RequireComponent(typeof(CustomTrigger))]
    public class DialogueTrigger : MonoBehaviour
    {
        public bool hasTriggered = false;
        private void Start()
        {
            GetComponent<CustomTrigger>().OnPlayerEnter += OnPlayerEnterOrExit;
            GetComponent<CustomTrigger>().OnPlayerExit += OnPlayerEnterOrExit;
        }
        
        void OnPlayerEnterOrExit()
        {
            hasTriggered = true;
        }
    }
}