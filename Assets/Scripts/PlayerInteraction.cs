using System;
using TarodevController;
using Unity.VisualScripting;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private float interactionDistance = 2f;
        [SerializeField] private KeyCode interactButton;
        [SerializeField] private LayerMask interactableLayer;

        private void Update()
        {
            if(Input.GetKeyDown(interactButton))
                CheckForInteractable();
        }

        private void CheckForInteractable()
        {
            //raycast to the left and righ
            RaycastHit2D hit1, hit2;
            
            hit1 = Physics2D.Raycast(PlayerLocationBroadcaster.Instance.transform.position, Vector2.right, interactionDistance,interactableLayer);
            hit2 = Physics2D.Raycast(PlayerLocationBroadcaster.Instance.transform.position, Vector2.left, interactionDistance,interactableLayer);
            
            if(hit1 && hit1.collider.GetComponent<IInteractable>() != null){
                hit1.collider.GetComponent<IInteractable>().OnInteract();
                Debug.Log(hit1.collider.name);
                
            }
            else if (hit2 && hit2.collider.GetComponent<IInteractable>() != null)
            {
                
                hit2.collider.GetComponent<IInteractable>().OnInteract();
            Debug.Log(hit2.collider.name);
            }

        }

        
        
    }
    
}