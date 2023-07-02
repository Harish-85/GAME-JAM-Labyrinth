using System.Collections;
using System.Collections.Generic;
using TarodevController;
using UnityEngine;

public class Shop :MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject shopUI;

    [SerializeField] private int keyCost = 10;
    [SerializeField] private int torchCost = 10;
    
    [SerializeField] private float distanceToExit = 4f;
    private bool _canInteract;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OnExitShop();
        }
        
        DistanceCheck();
        
    }
    
    void DistanceCheck()
    {
        if(Vector3.Distance(transform.position, PlayerLocationBroadcaster.Instance.GetPlayerLocation()) > distanceToExit)
            OnExitShop();
    }

    public void OnInteract()
    {
        shopUI.SetActive(true);
    }

    bool IInteractable.CanInteract
    {
        get => _canInteract;
        set => _canInteract = value;
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
