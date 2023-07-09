using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(CustomTrigger))]
    public class ActivateOnTrigger : MonoBehaviour
    {
        [SerializeField] private  GameObject teleporter;
        private void Start()
        {
            GetComponent<CustomTrigger>().OnPlayerEnter += OnPlayerEnterOrExit;
            GetComponent<CustomTrigger>().OnPlayerExit += OnPlayerEnterOrExit;
        }

        void OnPlayerEnterOrExit()
        {
            teleporter.SetActive(true);
        }
    }
}