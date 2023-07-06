using System;
using UnityEngine;
using UnityEngine.Events;

namespace TarodevController
{
    public class TimeManager : MonoBehaviour
    {
        //singleton
        public static TimeManager Instance;

        public float timePassed;
        public float totalTime = 60f;
        
        public event UnityAction OnTimePassed;

        private bool isTimeExpired = false;
        
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            
        }

        private void Update()
        {

            if (isTimeExpired)
                return;
            
            timePassed += Time.deltaTime;
            if (timePassed >= totalTime)
            {
                OnTimePassed?.Invoke();
            }
        }
    }
}