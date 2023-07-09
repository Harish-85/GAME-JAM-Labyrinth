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
    [SerializeField] private TextMeshProUGUI SpecialKeyCostText;
    [SerializeField] private float distanceToExit = 4f;
    private bool _canInteract;
    
    [SerializeField] private int keyLimit = 10;
    [SerializeField] private int torchLimit = 2;
    [SerializeField] private int specialKeyLimit = 1;

    private int keysSold = 0;
    private int torchesSold = 0;
    private int specialKeysSold = 0;

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
        SpecialKeyCostText.text = PlayerInventory.Inventory.specialKeyCount.ToString();
        LimitCheck();
    }

    void LimitCheck()
    {
        if(keysSold >= keyLimit)
            keyCostText.transform.parent.gameObject.SetActive(false);
        if(torchesSold >= torchLimit)
            torchCostText.transform.parent.gameObject.SetActive(false);
        if(specialKeysSold >= specialKeyLimit)
            SpecialKeyCostText.transform.parent.gameObject.SetActive(false);
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
        keysSold++;
    }
    
    public void OnPurchaseTorch()
    {
        if(PlayerInventory.Inventory.GetMoney() < torchCost)
            return;
        PlayerInventory.Inventory.RemoveMoney(torchCost);
        PlayerInventory.Inventory.AddTorch();
        torchesSold++;
    }
    public void OnExitShop()
    {
        shopUI.SetActive(false);
    }
    
    public void OnPurchaseSpecialKey()
    {
        if (PlayerInventory.Inventory.GetMoney() < keyCost)
            return;
        
        PlayerInventory.Inventory.RemoveMoney(keyCost);
        PlayerInventory.Inventory.AddSpecialKey();
        specialKeysSold++;
    }
    
}
