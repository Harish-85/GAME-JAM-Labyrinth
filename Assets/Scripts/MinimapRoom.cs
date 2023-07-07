using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class MinimapRoom : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player"))
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}