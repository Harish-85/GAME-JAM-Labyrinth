using System.Collections;
using System.Collections.Generic;
using TarodevController;
using TMPro;
using UnityEngine;

//maybe needs some refactoring . And I am not gonna do it
public class Shop :MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject shopUI;

    [SerializeField] private int keyCost = 10;
    [SerializeField] private int torchCost = 10;
    [SerializeField] private TextMeshProUGUI keyCostText;
    [SerializeField] private TextMeshProUGUI torchCostText;
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
        keyCostText.text = PlayerInventory.Inventory.GetKey().ToString();
        torchCostText.text = PlayerInventory.Inventory.GetTorch().ToString();
    }
    
    void DistanceCheck()
    {
        if(Vector3.Distance(transform.position, PlayerLocationBroadcaster.Instance.GetPlayerLocation()) > distanceToExit)
            OnExitShop();
    }

    public void OnInteract()
    {
        float time =CheckForDialogue();
        Invoke(nameof(EnableShop),time);
    }
    
    void EnableShop()
    {
        shopUI.SetActive(true);
    }
    
    float CheckForDialogue()
    {
        return PlayerDialogueManager.Instance.PlayLatestFlag();
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
