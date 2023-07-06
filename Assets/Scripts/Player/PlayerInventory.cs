using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public static PlayerInventory Inventory;

    public int keyCount = 0;
    public int moneyCount = 0;
    public int torchCount = 0;
    
    
    private void Awake()
    {
        if (Inventory == null)
        {
            Inventory = this;
        }
    }

    
    public void AddTorch()
    {
        torchCount += 1;
    }
    
    public void AddMoney()
    {
        moneyCount += 1;
    }
    
    public void AddKey()
    {
        keyCount += 1;
    }
    
    public int GetTorch()
    {
        return torchCount;
    }
    public int GetMoney()
    {
        return moneyCount;
    }
    public int GetKey()
    {
        return keyCount;
    }
    
    
    public void RemoveTorch()
    {
        torchCount -= 1;
    }
    public void RemoveMoney(int amount)
    {
        moneyCount -= amount;
    }
    public void RemoveKey()
    {
        keyCount -= 1;
    }
    
}
