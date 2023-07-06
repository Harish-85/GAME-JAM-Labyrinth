using System;
using UnityEngine;

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