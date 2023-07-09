using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(CustomTrigger))]
    public class StartGuppy : MonoBehaviour
    {
        [SerializeField] private GameObject guppy;
        private void Start()
        {
            GetComponent<CustomTrigger>().OnPlayerEnter += OnPlayerEnterOrExit;
            GetComponent<CustomTrigger>().OnPlayerExit += OnPlayerEnterOrExit;
        }
        
        void OnPlayerEnterOrExit()
        {
            guppy.SetActive(true);
        }
        
    }
}