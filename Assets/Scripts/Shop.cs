using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop :MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject shopUI;

    [SerializeField] private int keyCost = 10;
    [SerializeField] private int torchCost = 10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitShop();
        }
    }

    public void OnInteract()
    {
        shopUI.SetActive(true);
    }

    public void OnPurchaseKey()
    {
        if (PlayerInventory.Inventory.GetMoney() < keyCost)
            return;
        
        PlayerInventory.Inventory.RemoveMoney(keyCost);
        PlayerInventory.Inventory.AddKey();
    }
    
    public void OnPurchaseTorch()
    {
        if(PlayerInventory.Inventory.GetMoney() < torchCost)
            return;
        PlayerInventory.Inventory.RemoveMoney(torchCost);
        PlayerInventory.Inventory.AddTorch();
    }
    public void OnExitShop()
    {
        shopUI.SetActive(false);
    }
    
}
