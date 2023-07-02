using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class TorchPlacement : MonoBehaviour,IInteractable
{

    public bool CanInteract { get; set; }
    [SerializeField]private List<Light2D> lights;
    
    [SerializeField] private float lightIntensity = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnInteract()
    {
        if (!CanInteract)
            return;
        
        if (PlayerInventory.Inventory.GetTorch() > 0)
        {
            PlayerInventory.Inventory.RemoveTorch();
            CanInteract = false;
            foreach (var l in lights)
            {
                l.intensity = lightIntensity;
            }
            
        }
    }

}
