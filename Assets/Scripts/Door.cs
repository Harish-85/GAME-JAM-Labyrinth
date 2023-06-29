using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class Door : MonoBehaviour,IInteractable
{
    [SerializeField] Transform doorT;
    [SerializeField] private float doorOpenDistance = 2f;
    [SerializeField] private float doorOpenTime = 2f;
    
    private Vector3 _startPos;
    
    // Start is called before the first frame update
    void Start()
    {
        doorT = transform;
        _startPos = doorT.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    [ContextMenu("yoooo")]
    public void OnInteract()
    {
        if (PlayerInventory.Inventory.GetKey() <= 0)
            return;
        OpenDoor();
        PlayerInventory.Inventory.RemoveKey();
    }

    private void OpenDoor()
    {
        //open door
        LeanTween.moveY(doorT.gameObject, _startPos.y + doorOpenDistance, doorOpenTime).setEaseOutQuad();
        CameraShake.Instance.Shake(1.5f, .5f);
        Invoke(nameof(DisableDoor), doorOpenTime);
    }

    void DisableDoor()
    {
        this.gameObject.SetActive(false);
    }
}
