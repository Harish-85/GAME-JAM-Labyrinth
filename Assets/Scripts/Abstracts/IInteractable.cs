using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//To the person who invented Interfaces : Thank you
public interface IInteractable
{ 
    public void OnInteract();
    public bool CanInteract { get; set; }
}
