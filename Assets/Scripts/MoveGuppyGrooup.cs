using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGuppyGrooup : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerDeathManager.DeathManager.OnDie();
        }
    }
}
