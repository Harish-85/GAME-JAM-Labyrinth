using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpecialDOor : MonoBehaviour,IInteractable
{
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
        
        if (PlayerInventory.Inventory.specialKeyCount >= 4)
        {
            PlayerInventory.Inventory.specialKeyCount = 0;
            CanInteract = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public bool CanInteract { get; set; } = true;
}
