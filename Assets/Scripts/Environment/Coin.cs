using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CustomTrigger))]
public class Coin : MonoBehaviour
{
    private CustomTrigger _trigger;
    [SerializeField] private float roateSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        _trigger = GetComponent<CustomTrigger>();
        _trigger.OnPlayerEnter += OnPlayerEnter;
    }

    private void OnPlayerEnter()
    {
        PlayerInventory.Inventory.AddMoney();
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * roateSpeed * Time.deltaTime);
    }
}
