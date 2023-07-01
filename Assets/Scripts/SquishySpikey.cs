using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquishySpikey : MonoBehaviour
{
    [SerializeField]private float extendendPosition = 2;

    [SerializeField] private float extendRetractTime = 1f;
    [SerializeField] private float waitTime = 1f;
    
    [SerializeField] private float rayWidth = 2;
    [SerializeField] private float rayLength = 2;
    [SerializeField] private int rayCount = 5;
    [SerializeField] private float rayCastOffset = 0.5f;
    private Vector3 neutralPosition;
    // Start is called before the first frame update
    void Start()
    {
        neutralPosition = transform.position;
        Extract();
    }

    // Update is called once per frame
    void Update()
    {
        
        CollisionCheck();
        
    }

    void CollisionCheck()
    {
        //cast ray counts number of rays in the downward direction
        for (int i = 0; i < rayCount; i++)
        {
            Vector3 rayOrigin = transform.position + new Vector3(-rayWidth / 2 + rayWidth / (rayCount - 1) * i, rayCastOffset, 0);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, -transform.up, rayLength);
            
            //debug ray
            Debug.DrawRay(rayOrigin, -transform.up * rayLength, Color.red);
            if (hit.collider != null)
            {
                Debug.Log("Hit");
                //if the ray hits the player, kill the player
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player hit");
                    
                }
            }
        }
    }

    void Extract()
    {
        LeanTween.move(gameObject, transform.position +(- transform.up * extendendPosition), extendRetractTime).setOnComplete(Retract);
    }

    void Retract()
    {
        LeanTween.move(gameObject, neutralPosition, extendRetractTime).setOnComplete(PreExtract);
    }

    void PreExtract()
    {
        Invoke(nameof(Extract), waitTime);
    }
}
